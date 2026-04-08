namespace Auth0.MyOrganizationApi;

/// <summary>
/// Auth0 My Organization API client with automatic token management.
/// </summary>
/// <remarks>
/// This is the recommended entry point for the Auth0 My Organization API. It wraps the
/// low-level <see cref="MyOrganizationApiClient"/> and adds token management via
/// <see cref="ITokenProvider"/>.
/// <para>
/// Configure the target tenant by setting <see cref="MyOrganizationClientOptions.Domain"/>
/// (e.g., <c>"your-tenant.auth0.com"</c>). The Base URL is constructed automatically as
/// <c>https://{Domain}/my-org</c>. Alternatively, set
/// <see cref="MyOrganizationClientOptions.BaseUrl"/> directly to override this behaviour.
/// </para>
/// <para>
/// Token handling is provided by an <see cref="ITokenProvider"/>:
/// <list type="bullet">
///   <item><see cref="DelegateTokenProvider"/> — retrieve tokens from a custom async source.</item>
///   <item><see cref="ClientCredentialsTokenProvider"/> — automatic token acquisition and refresh via OAuth 2.0 client credentials.</item>
/// </list>
/// </para>
/// Example (client credentials):
/// <code>
/// var tokenProvider = ClientCredentialsTokenProvider
///     .WithClientSecret("tenant.auth0.com", "client_id", "client_secret")
///     .Build();
///
/// var client = new MyOrganizationClient(new MyOrganizationClientOptions
/// {
///     Domain = "tenant.auth0.com",
///     TokenProvider = tokenProvider
/// });
/// </code>
/// </remarks>
public sealed class MyOrganizationClient : MyOrganizationApiClient, IDisposable
{
    private readonly HttpClient? _ownedHttpClient;
    private readonly ITokenProvider _tokenProvider;

    /// <summary>
    /// Creates a new <see cref="MyOrganizationClient"/> instance.
    /// </summary>
    /// <param name="options">Configuration options for the client.</param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="options"/> is null or when
    /// <see cref="MyOrganizationClientOptions.TokenProvider"/> is null.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown when neither <see cref="MyOrganizationClientOptions.Domain"/> nor
    /// <see cref="MyOrganizationClientOptions.BaseUrl"/> is set.
    /// </exception>
    public MyOrganizationClient(MyOrganizationClientOptions options)
        : this(Validate(options), BuildClientOptions(options))
    {
    }

    private MyOrganizationClient(MyOrganizationClientOptions options, ClientOptions clientOptions)
        : base(null, clientOptions)
    {
        _tokenProvider = options.TokenProvider;
        _ownedHttpClient = options.HttpClient == null ? clientOptions.HttpClient : null;

        // Replace the static "Bearer " auth header with a dynamic per-request supplier.
        SetAuthorizationHeader(async () =>
            $"Bearer {await _tokenProvider.GetTokenAsync(default).ConfigureAwait(false)}");
    }

    private static MyOrganizationClientOptions Validate(MyOrganizationClientOptions options)
    {
        if (options == null)
            throw new ArgumentNullException(nameof(options));
        if (options.TokenProvider == null)
            throw new ArgumentNullException(
                nameof(MyOrganizationClientOptions.TokenProvider), "TokenProvider must not be null.");
        if (string.IsNullOrWhiteSpace(options.Domain) && string.IsNullOrWhiteSpace(options.BaseUrl))
            throw new ArgumentException(
                "Either Domain or BaseUrl must be set.",
                nameof(MyOrganizationClientOptions.Domain));

        if (!string.IsNullOrWhiteSpace(options.Domain) && string.IsNullOrWhiteSpace(options.BaseUrl))
        {
            var domain = options.Domain.Trim();
            if (domain.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                domain.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException(
                    "Domain must not include a URL scheme (e.g. use \"tenant.auth0.com\", not \"https://tenant.auth0.com\").",
                    nameof(MyOrganizationClientOptions.Domain));
            if (domain.Contains('/'))
                throw new ArgumentException(
                    "Domain must not include a path or trailing slash (e.g. use \"tenant.auth0.com\").",
                    nameof(MyOrganizationClientOptions.Domain));
        }

        return options;
    }

    private static ClientOptions BuildClientOptions(MyOrganizationClientOptions options)
    {
        var domain = options.Domain?.Trim();
        var clientOptions = new ClientOptions
        {
            BaseUrl = options.BaseUrl ?? $"https://{domain}/my-org",
            HttpClient = options.HttpClient ?? new HttpClient(),
            Timeout = options.Timeout ?? TimeSpan.FromSeconds(30),
            MaxRetries = options.MaxRetries ?? 2,
        };

        if (options.AdditionalHeaders != null)
        {
            foreach (var header in options.AdditionalHeaders)
            {
                if (header.Value != null)
                    clientOptions.Headers[header.Key] = header.Value;
            }
        }

        return clientOptions;
    }

    /// <summary>
    /// Disposes the <see cref="MyOrganizationClient"/> and releases managed resources.
    /// Only disposes the internal <see cref="HttpClient"/> if it was created by this instance.
    /// The <see cref="ITokenProvider"/> is not disposed — the caller owns it and is responsible for its lifetime.
    /// </summary>
    public void Dispose()
    {
        _ownedHttpClient?.Dispose();
    }
}
