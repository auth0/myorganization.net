namespace Auth0.MyOrganizationApi;

/// <summary>
/// Configuration options for <see cref="MyOrganizationClient"/>.
/// </summary>
public sealed class MyOrganizationClientOptions
{
    /// <summary>
    /// The token provider responsible for supplying access tokens.
    ///
    /// Built-in options:
    /// <list type="bullet">
    ///   <item><see cref="DelegateTokenProvider"/> — for retrieving tokens from an external source (e.g., a secret manager).</item>
    ///   <item><see cref="ClientCredentialsTokenProvider"/> — for automatic token acquisition and refresh via client credentials.</item>
    /// </list>
    ///
    /// Implement <see cref="ITokenProvider"/> to supply tokens from any custom source.
    /// </summary>
    public required ITokenProvider TokenProvider { get; init; }

    /// <summary>
    /// Custom <see cref="System.Net.Http.HttpClient"/> for making API requests.
    /// If not provided, a new instance will be created and managed internally.
    /// </summary>
    public HttpClient? HttpClient { get; init; }

    /// <summary>
    /// Request timeout. Defaults to 30 seconds.
    /// </summary>
    public TimeSpan? Timeout { get; init; }

    /// <summary>
    /// Maximum number of retry attempts for failed requests. Defaults to 2.
    /// </summary>
    public int? MaxRetries { get; init; }

    /// <summary>
    /// Additional headers to include with every request.
    /// </summary>
    public IEnumerable<KeyValuePair<string, string?>>? AdditionalHeaders { get; init; }

    /// <summary>
    /// The Auth0 domain for your tenant (e.g., <c>"your-tenant.auth0.com"</c>).
    /// </summary>
    /// <remarks>
    /// Used to construct the Base URL as <c>https://{Domain}/my-org</c>.
    /// Must not include a scheme prefix (e.g., do not use <c>"https://your-tenant.auth0.com"</c>).
    /// <para>
    /// Either <see cref="Domain"/> or <see cref="BaseUrl"/> must be set.
    /// If both are provided, <see cref="BaseUrl"/> takes precedence.
    /// </para>
    /// </remarks>
    public string? Domain { get; init; }

    /// <summary>
    /// Explicit Base URL for the API (e.g., <c>"https://your-tenant.auth0.com/my-org"</c>).
    /// </summary>
    /// <remarks>
    /// When set, takes precedence over <see cref="Domain"/> and is used as-is.
    /// If not set, the Base URL is constructed automatically from <see cref="Domain"/>.
    /// <para>
    /// Use this when you need to target a non-standard endpoint or a local test server.
    /// For normal tenant access, prefer setting <see cref="Domain"/> instead.
    /// </para>
    /// </remarks>
    public string? BaseUrl { get; init; }
}
