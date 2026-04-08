namespace Auth0.MyOrganizationApi;

public partial class MyOrganizationApiClient
{
    /// <summary>
    /// Replaces the Authorization header with a dynamic supplier that is evaluated per-request.
    /// Used by <see cref="MyOrganizationClient"/> to wire in <see cref="ITokenProvider"/> support.
    /// </summary>
    internal void SetAuthorizationHeader(Func<Task<string>> supplier)
    {
        _client.Options.Headers["Authorization"] = supplier;
    }
}
