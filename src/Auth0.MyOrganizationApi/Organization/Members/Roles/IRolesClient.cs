using Auth0.MyOrganizationApi;
using Auth0.MyOrganizationApi.Core;

namespace Auth0.MyOrganizationApi.Organization.Members;

public partial interface IRolesClient
{
    /// <summary>
    /// Retrieve a list of roles assigned to a member specified by ID for this Organization.
    /// </summary>
    Task<Pager<Role>> ListAsync(
        string userId,
        ListOrgMemberRolesRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Assign roles to a member specified by ID for this Organization.
    /// </summary>
    Task AssignAsync(
        string userId,
        OrganizationMemberRolesChangeRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove roles from a member specified by ID for this Organization.
    /// </summary>
    Task UnassignAsync(
        string userId,
        OrganizationMemberRolesChangeRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
