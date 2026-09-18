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
    /// Create a domain for an Auth0 Organization and optionally enable Organization Discovery for members during the user login flow
    /// </summary>
    WithRawResponseTask<OrgDomain> CreateAsync(
        CreateOrganizationDomainRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve the details of an Auth0 Organization domain using its unique domain ID, including the domain name and its current verification status.
    /// </summary>
    WithRawResponseTask<OrgDomain> GetAsync(
        string domainId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete an Auth0 Organization domain using its unique domain ID, including all associated details and verification status.
    /// </summary>
    Task DeleteAsync(
        string domainId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
