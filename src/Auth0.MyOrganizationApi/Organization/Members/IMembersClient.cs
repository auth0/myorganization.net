using Auth0.MyOrganizationApi;
using Auth0.MyOrganizationApi.Core;

namespace Auth0.MyOrganizationApi.Organization;

public partial interface IMembersClient
{
    public Auth0.MyOrganizationApi.Organization.Members.IRolesClient Roles { get; }

    /// <summary>
    /// Retrieve a list of all members for this Organization. The `roles` field is only included for each member when the token also carries the `read:my_org:member_roles` scope; without that scope the `roles` field is omitted from the response.
    /// </summary>
    Task<Pager<OrgMember>> ListAsync(
        ListOrganizationMembersRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve details of a member specified by user ID for this Organization.
    /// </summary>
    WithRawResponseTask<OrgMember> GetAsync(
        string userId,
        GetOrganizationMemberRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
