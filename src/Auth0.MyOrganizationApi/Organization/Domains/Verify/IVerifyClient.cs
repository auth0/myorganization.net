using Auth0.MyOrganizationApi;

namespace Auth0.MyOrganizationApi.Organization.Domains;

public partial interface IVerifyClient
{
    /// <summary>
    /// Get a verification text and start the domain verification process for a particular domain.
    /// </summary>
    WithRawResponseTask<OrgDomain> CreateAsync(
        string domainId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
