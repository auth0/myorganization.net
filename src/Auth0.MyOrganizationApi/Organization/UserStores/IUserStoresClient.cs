using Auth0.MyOrganizationApi;

namespace Auth0.MyOrganizationApi.Organization;

public partial interface IUserStoresClient
{
    /// <summary>
    /// Retrieve the user stores for the associated Organization.
    /// </summary>
    WithRawResponseTask<ListUserStoresResponseContent> ListAsync(
        ListOrganizationUserStoresRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
