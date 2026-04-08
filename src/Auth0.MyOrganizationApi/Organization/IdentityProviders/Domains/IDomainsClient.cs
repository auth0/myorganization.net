using Auth0.MyOrganizationApi;

namespace Auth0.MyOrganizationApi.Organization.IdentityProviders;

public partial interface IDomainsClient
{
    /// <summary>
    /// Add a domain to the identity provider's list of domains for [Home Realm Discovery (HRD)](https://auth0.com/docs/get-started/architecture-scenarios/business-to-business/authentication#home-realm-discovery). The domain passed must be claimed and verified by this organization.
    /// </summary>
    WithRawResponseTask<CreateIdpDomainResponseContent> CreateAsync(
        string idpId,
        CreateIdpDomainRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove a domain from an identity provider.
    /// </summary>
    Task DeleteAsync(
        string idpId,
        string domain,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
