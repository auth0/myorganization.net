using Auth0.MyOrganizationApi;

namespace Auth0.MyOrganizationApi.Organization.Configuration;

public partial interface IIdentityProvidersClient
{
    /// <summary>
    /// Retrieve the connection profile for the application. This will give the components all of the information they will need to be successful. The SDK provider for the components should manage fetching and caching this information for all components.
    /// </summary>
    WithRawResponseTask<IdentityProvidersConfig> GetAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
