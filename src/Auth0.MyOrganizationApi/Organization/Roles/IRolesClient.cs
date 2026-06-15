using Auth0.MyOrganizationApi;
using Auth0.MyOrganizationApi.Core;

namespace Auth0.MyOrganizationApi.Organization;

public partial interface IRolesClient
{
    /// <summary>
    /// Retrieve the list of roles available for binding to members and invitations for this Organization. Only roles made visible to this Organization by the Tenant Admin are returned.
    /// </summary>
    Task<Pager<Role>> ListAsync(
        ListRolesRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
