using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Microsoft.IdentityModel.Tokens;

namespace Auth0.MyOrganizationApi;

/// <summary>
/// An <see cref="ITokenProvider"/> that automatically acquires and caches tokens
/// via the OAuth 2.0 client credentials grant.
///
/// Tokens are cached until they expire (with a 10-second leeway for safety) and
/// refreshed transparently on the next call. Thread-safe.
/// </summary>
/// <example>
/// <code>
/// // Client secret auth
/// var provider = ClientCredentialsTokenProvider
///     .WithClientSecret("tenant.auth0.com", "clientId", "clientSecret")
///     .WithAudience("https://api.example.com/")
///     .Build();
///
/// // Client assertion auth
/// var provider = ClientCredentialsTokenProvider
///     .WithClientAssertion("tenant.auth0.com", "clientId", rsaKey, "RS256")
///     .Build();
/// </code>
/// </example>
public sealed class ClientCredentialsTokenProvider : ITokenProvider, IDisposable
{
    private readonly string _clientId;
    private readonly string? _clientSecret;
    private readonly SecurityKey? _clientAssertionSecurityKey;
    private readonly string? _clientAssertionSecurityKeyAlgorithm;
    private readonly string _audience;
    private readonly string? _organization;
    private readonly JwtSignatureAlgorithm _signingAlgorithm;
    private readonly AuthenticationApiClient _authClient;
    private readonly HttpClient? _ownedHttpClient;

    private class TokenState(string accessToken, DateTime expiresAt)
    {
        public string AccessToken { get; } = accessToken;
        public DateTime ExpiresAt { get; } = expiresAt;
    }

    private TokenState? _tokenState;
    private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
    private volatile bool _disposed;

    private const int LeewaySeconds = 10;

    private ClientCredentialsTokenProvider(
        string domain,
        string clientId,
        string? clientSecret,
        SecurityKey? clientAssertionSecurityKey,
        string? clientAssertionSecurityKeyAlgorithm,
        string audience,
        string? organization,
        JwtSignatureAlgorithm signingAlgorithm,
        HttpClient? httpClient)
    {
        _clientId = clientId;
        _clientSecret = clientSecret;
        _clientAssertionSecurityKey = clientAssertionSecurityKey;
        _clientAssertionSecurityKeyAlgorithm = clientAssertionSecurityKeyAlgorithm;
        _audience = audience;
        _organization = organization;
        _signingAlgorithm = signingAlgorithm;

        _ownedHttpClient = httpClient == null ? new HttpClient() : null;
        var effectiveHttpClient = httpClient ?? _ownedHttpClient!;

        _authClient = new AuthenticationApiClient(
            domain, new HttpClientAuthenticationConnection(effectiveHttpClient));
    }

    /// <summary>
    /// Creates a <see cref="Builder"/> configured to authenticate using a client secret.
    /// </summary>
    /// <param name="domain">
    /// The Auth0 domain (e.g., "your-tenant.auth0.com").
    /// Must not include a scheme prefix such as "https://".
    /// </param>
    /// <param name="clientId">The OAuth client ID.</param>
    /// <param name="clientSecret">The OAuth client secret.</param>
    /// <returns>A <see cref="Builder"/> for further configuration.</returns>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="domain"/>, <paramref name="clientId"/>, or
    /// <paramref name="clientSecret"/> is null, empty, or whitespace; or when
    /// <paramref name="domain"/> contains a scheme prefix.
    /// </exception>
    public static Builder WithClientSecret(string domain, string clientId, string clientSecret)
    {
        ValidateDomain(domain);
        if (string.IsNullOrWhiteSpace(clientId))
            throw new ArgumentException(
                "Client ID must not be null, empty, or whitespace.", nameof(clientId));
        if (string.IsNullOrWhiteSpace(clientSecret))
            throw new ArgumentException(
                "Client secret must not be null, empty, or whitespace.", nameof(clientSecret));

        return new Builder(domain, clientId, clientSecret, null, null);
    }

    /// <summary>
    /// Creates a <see cref="Builder"/> configured to authenticate using a client assertion (private_key_jwt).
    /// </summary>
    /// <param name="domain">
    /// The Auth0 domain (e.g., "your-tenant.auth0.com").
    /// Must not include a scheme prefix such as "https://".
    /// </param>
    /// <param name="clientId">The OAuth client ID.</param>
    /// <param name="clientAssertionSecurityKey">The <see cref="SecurityKey"/> used to sign the client assertion JWT.</param>
    /// <param name="clientAssertionSecurityKeyAlgorithm">The algorithm used with the security key (e.g., "RS256").</param>
    /// <returns>A <see cref="Builder"/> for further configuration.</returns>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="domain"/>, <paramref name="clientId"/>, or
    /// <paramref name="clientAssertionSecurityKeyAlgorithm"/> is null, empty, or whitespace; or when
    /// <paramref name="domain"/> contains a scheme prefix.
    /// </exception>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="clientAssertionSecurityKey"/> is null.
    /// </exception>
    public static Builder WithClientAssertion(
        string domain,
        string clientId,
        SecurityKey clientAssertionSecurityKey,
        string clientAssertionSecurityKeyAlgorithm)
    {
        ValidateDomain(domain);
        if (string.IsNullOrWhiteSpace(clientId))
            throw new ArgumentException(
                "Client ID must not be null, empty, or whitespace.", nameof(clientId));
        if (clientAssertionSecurityKey == null)
            throw new ArgumentNullException(nameof(clientAssertionSecurityKey),
                "Client assertion security key must not be null.");
        if (string.IsNullOrWhiteSpace(clientAssertionSecurityKeyAlgorithm))
            throw new ArgumentException(
                "Client assertion security key algorithm must not be null, empty, or whitespace.",
                nameof(clientAssertionSecurityKeyAlgorithm));

        return new Builder(domain, clientId, null, clientAssertionSecurityKey, clientAssertionSecurityKeyAlgorithm);
    }

    /// <summary>
    /// Returns a valid access token, fetching a new one from Auth0 if the cached
    /// token has expired or does not yet exist. Thread-safe.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ObjectDisposedException">Thrown if this instance has been disposed.</exception>
    public async Task<string> GetTokenAsync(CancellationToken cancellationToken = default)
    {
        if (_disposed)
            throw new ObjectDisposedException(GetType().FullName);

        // Fast path: return cached token if still valid.
        var state = Volatile.Read(ref _tokenState);
        if (state != null && DateTime.UtcNow < state.ExpiresAt.AddSeconds(-LeewaySeconds))
        {
            return state.AccessToken;
        }

        // Slow path: acquire semaphore, double-check, then fetch.
        await _semaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            state = Volatile.Read(ref _tokenState);
            if (state != null && DateTime.UtcNow < state.ExpiresAt.AddSeconds(-LeewaySeconds))
            {
                return state.AccessToken;
            }

            state = await FetchTokenAsync(cancellationToken).ConfigureAwait(false);
        }
        finally
        {
            _semaphore.Release();
        }

        return state.AccessToken;
    }

    private async Task<TokenState> FetchTokenAsync(CancellationToken cancellationToken)
    {
        var response = await _authClient.GetTokenAsync(new ClientCredentialsTokenRequest
        {
            ClientId = _clientId,
            ClientSecret = _clientSecret,
            ClientAssertionSecurityKey = _clientAssertionSecurityKey,
            ClientAssertionSecurityKeyAlgorithm = _clientAssertionSecurityKeyAlgorithm,
            Audience = _audience,
            Organization = _organization,
            SigningAlgorithm = _signingAlgorithm,
        }, cancellationToken).ConfigureAwait(false);

        if (string.IsNullOrWhiteSpace(response.AccessToken))
            throw new InvalidOperationException(
                "Auth0 returned a null or empty access token. Verify the client credentials and audience are correct.");

        // Guard against ExpiresIn values too small to be useful; avoids a tight
        // refresh loop where the token would be considered expired immediately.
        var effectiveExpiry = Math.Max(response.ExpiresIn, LeewaySeconds + 1);
        var newExpiry = DateTime.UtcNow.AddSeconds(effectiveExpiry);
        var newState = new TokenState(response.AccessToken, newExpiry);

        // Atomic update of both token and expiry
        Interlocked.Exchange(ref _tokenState, newState);
        return newState;
    }

    /// <summary>
    /// Releases resources held by this provider.
    /// </summary>
    public void Dispose()
    {
        _disposed = true;
        _semaphore.Dispose();
        _authClient.Dispose();
        _ownedHttpClient?.Dispose();
    }

    private static void ValidateDomain(string domain)
    {
        if (string.IsNullOrWhiteSpace(domain))
            throw new ArgumentException(
                "Domain must not be null, empty, or whitespace.", nameof(domain));
        if (domain.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
            domain.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            throw new ArgumentException(
                "Domain must not include a scheme prefix (e.g. use 'tenant.auth0.com', not 'https://tenant.auth0.com').",
                nameof(domain));
    }

    /// <summary>
    /// Fluent builder for constructing <see cref="ClientCredentialsTokenProvider"/> instances.
    /// </summary>
    /// <remarks>
    /// Obtain a builder via <see cref="WithClientSecret"/> or <see cref="WithClientAssertion"/>.
    /// These two entry points are mutually exclusive — the auth method is locked in at creation
    /// and cannot be changed via fluent methods.
    /// </remarks>
    public sealed class Builder
    {
        private readonly string _domain;
        private readonly string _clientId;
        private readonly string? _clientSecret;
        private readonly SecurityKey? _clientAssertionSecurityKey;
        private readonly string? _clientAssertionSecurityKeyAlgorithm;

        private string? _audience;
        private string? _organization;
        private HttpClient? _httpClient;
        private JwtSignatureAlgorithm _signingAlgorithm;

        internal Builder(
            string domain,
            string clientId,
            string? clientSecret,
            SecurityKey? clientAssertionSecurityKey,
            string? clientAssertionSecurityKeyAlgorithm)
        {
            _domain = domain;
            _clientId = clientId;
            _clientSecret = clientSecret;
            _clientAssertionSecurityKey = clientAssertionSecurityKey;
            _clientAssertionSecurityKeyAlgorithm = clientAssertionSecurityKeyAlgorithm;
        }

        /// <summary>
        /// Sets the API audience for token requests.
        /// If not called, defaults to <c>https://{domain}/my-org/</c>.
        /// </summary>
        /// <param name="audience">
        /// The API audience URI. Null or whitespace is treated as unset and the default is used.
        /// </param>
        /// <returns>This builder instance for method chaining.</returns>
        public Builder WithAudience(string? audience)
        {
            if (!string.IsNullOrWhiteSpace(audience))
                _audience = audience;
            return this;
        }

        /// <summary>
        /// Sets the Auth0 organization for token requests.
        /// When set, the returned access token will include <c>org_id</c> and <c>org_name</c> claims.
        /// </summary>
        /// <param name="organization">The organization name or ID. Null or whitespace is treated as unset.</param>
        /// <returns>This builder instance for method chaining.</returns>
        public Builder WithOrganization(string? organization)
        {
            if (!string.IsNullOrWhiteSpace(organization))
                _organization = organization;
            return this;
        }

        /// <summary>
        /// Supplies an <see cref="HttpClient"/> for making token requests.
        /// If not called, a new instance is created and managed internally.
        /// If provided, the caller retains ownership and is responsible for disposing it.
        /// </summary>
        /// <param name="httpClient">The HTTP client to use, or null to use an internally managed one.</param>
        /// <returns>This builder instance for method chaining.</returns>
        public Builder WithHttpClient(HttpClient? httpClient)
        {
            _httpClient = httpClient;
            return this;
        }

        /// <summary>
        /// Sets the JWT signature algorithm used to verify the signature of ID tokens.
        /// </summary>
        /// <param name="algorithm">The <see cref="JwtSignatureAlgorithm"/> to use.</param>
        /// <returns>This builder instance for method chaining.</returns>
        public Builder WithSigningAlgorithm(JwtSignatureAlgorithm algorithm)
        {
            _signingAlgorithm = algorithm;
            return this;
        }

        /// <summary>
        /// Constructs a <see cref="ClientCredentialsTokenProvider"/> from the current builder state.
        /// </summary>
        /// <returns>A configured <see cref="ClientCredentialsTokenProvider"/>.</returns>
        public ClientCredentialsTokenProvider Build() =>
            new ClientCredentialsTokenProvider(
                domain: _domain,
                clientId: _clientId,
                clientSecret: _clientSecret,
                clientAssertionSecurityKey: _clientAssertionSecurityKey,
                clientAssertionSecurityKeyAlgorithm: _clientAssertionSecurityKeyAlgorithm,
                audience: _audience ?? $"https://{_domain}/my-org/",
                organization: _organization,
                signingAlgorithm: _signingAlgorithm,
                httpClient: _httpClient);
    }
}
