using Auth0.MyOrganizationApi;

namespace Auth0.MyOrganizationApi.Organization.Domains;

public partial interface IIdentityProvidersClient
{
    /// <summary>
    /// Retrieve the list of Identity Providers associated with a domain specified by ID for this Organization.
    /// </summary>
    WithRawResponseTask<ListDomainIdentityProvidersResponseContent> ListAsync(
        string domainId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
