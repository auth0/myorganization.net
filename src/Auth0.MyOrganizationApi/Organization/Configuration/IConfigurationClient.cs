using Auth0.MyOrganizationApi;

namespace Auth0.MyOrganizationApi.Organization;

public partial interface IConfigurationClient
{
    public Auth0.MyOrganizationApi.Organization.Configuration.IIdentityProvidersClient IdentityProviders { get; }

    /// <summary>
    /// Retrieve the configuration for the /my-org API. This will return all stored client information with the exception of attributes that are identifiers. Identifier attributes will be given their own endpoint that will return the full object. This will give the components all of the information they will need to be successful. The SDK provider for the components should manage fetching and caching this information for all components.
    /// </summary>
    WithRawResponseTask<GetConfigurationResponseContent> GetAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
