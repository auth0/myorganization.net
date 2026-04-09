using Auth0.MyOrganizationApi;
using Auth0.MyOrganizationApi.Core;
using Auth0.MyOrganizationApi.Organization.Domains;

namespace Auth0.MyOrganizationApi.Organization;

public partial interface IDomainsClient
{
    public IVerifyClient Verify { get; }
    public Auth0.MyOrganizationApi.Organization.Domains.IIdentityProvidersClient IdentityProviders { get; }

    /// <summary>
    /// Retrieve a list of all pending and verified domains for this Organization.
    /// </summary>
    Task<Pager<OrgDomain>> ListAsync(
        ListOrganizationDomainsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a new domain for this Organization.
    /// </summary>
    WithRawResponseTask<OrgDomain> CreateAsync(
        CreateOrganizationDomainRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve details of a domain specified by ID for this Organization.
    /// </summary>
    WithRawResponseTask<OrgDomain> GetAsync(
        string domainId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove a domain specified by ID from this Organization.
    /// </summary>
    Task DeleteAsync(
        string domainId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
