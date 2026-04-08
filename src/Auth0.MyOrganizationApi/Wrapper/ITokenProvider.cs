namespace Auth0.MyOrganizationApi;

/// <summary>
/// Provides access tokens for API authentication.
/// Implement this interface to support any token strategy:
/// static tokens, OAuth 2.0 client credentials, external vaults, custom caches, and more.
/// <list type="bullet">
///   <item><see cref="DelegateTokenProvider"/> — retrieve tokens from a custom async source.</item>
///   <item><see cref="ClientCredentialsTokenProvider"/> — automatic token acquisition and refresh via OAuth 2.0 client credentials.</item>
/// </list>
/// </summary>
public interface ITokenProvider
{
    /// <summary>
    /// Returns a valid access token, fetching or refreshing as needed.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    Task<string> GetTokenAsync(CancellationToken cancellationToken = default);
}
