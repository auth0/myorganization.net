using Auth0.MyOrganizationApi;

namespace Auth0.MyOrganizationApi.Organization.Domains;

public partial interface IIdentityProvidersClient
{
    /// <summary>
    /// Retrieve the list of identity providers that have a specific organization domain alias.
    /// </summary>
    WithRawResponseTask<ListDomainIdentityProvidersResponseContent> GetAsync(
        string domainId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
