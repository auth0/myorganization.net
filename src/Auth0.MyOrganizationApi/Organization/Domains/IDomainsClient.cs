using Auth0.MyOrganizationApi;
using Auth0.MyOrganizationApi.Organization.Domains;

namespace Auth0.MyOrganizationApi.Organization;

public partial interface IDomainsClient
{
    public IVerifyClient Verify { get; }
    public Auth0.MyOrganizationApi.Organization.Domains.IIdentityProvidersClient IdentityProviders { get; }

    /// <summary>
    /// Lists all domains pending and verified for an organization.
    /// </summary>
    WithRawResponseTask<ListOrganizationDomainsResponseContent> ListAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a new domain for an organization.
    /// </summary>
    WithRawResponseTask<OrgDomain> CreateAsync(
        CreateOrganizationDomainRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a domain for an organization.
    /// </summary>
    WithRawResponseTask<OrgDomain> GetAsync(
        string domainId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove a domain from this organization.
    /// </summary>
    Task DeleteAsync(
        string domainId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
