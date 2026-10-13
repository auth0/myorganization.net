using Auth0.MyOrganizationApi;

namespace Auth0.MyOrganizationApi.Organization;

public partial interface IMembershipsClient
{
    /// <summary>
    /// Remove one member from this Organization. The underlying user account is not deleted.
    /// </summary>
    WithRawResponseTask DeleteMembershipsAsync(
        DeleteOrganizationMembershipsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
