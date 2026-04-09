using Auth0.MyOrganizationApi;

namespace Auth0.MyOrganizationApi.Organization.Domains;

public partial interface IVerifyClient
{
    /// <summary>
    /// Initiate the verification process for a domain specified by ID for this Organization.
    /// </summary>
    WithRawResponseTask<OrgDomain> CreateAsync(
        string domainId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
