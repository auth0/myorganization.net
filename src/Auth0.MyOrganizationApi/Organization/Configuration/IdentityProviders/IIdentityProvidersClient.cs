using Auth0.MyOrganizationApi;

namespace Auth0.MyOrganizationApi.Organization.Configuration;

public partial interface IIdentityProvidersClient
{
    /// <summary>
    /// Retrieve the [Connection Profile](https://auth0.com/docs/authenticate/enterprise-connections/connection-profile) for this application. You should cache this information as it does not change frequently.
    /// </summary>
    WithRawResponseTask<IdentityProvidersConfig> GetAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
