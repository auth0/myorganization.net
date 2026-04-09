using Auth0.MyOrganizationApi;

namespace Auth0.MyOrganizationApi.Organization.IdentityProviders;

public partial interface IDomainsClient
{
    /// <summary>
    /// Associate a domain with an Identity Provider specified by ID for this Organization. The domain must be claimed and verified.
    /// </summary>
    WithRawResponseTask<CreateIdpDomainResponseContent> CreateAsync(
        string idpId,
        CreateIdpDomainRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove a domain specified by name from an Identity Provider specified by ID for this Organization.
    /// </summary>
    Task DeleteAsync(
        string idpId,
        string domain,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
