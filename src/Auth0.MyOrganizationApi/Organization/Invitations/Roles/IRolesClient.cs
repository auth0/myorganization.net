using Auth0.MyOrganizationApi;

namespace Auth0.MyOrganizationApi.Organization.Invitations;

public partial interface IRolesClient
{
    /// <summary>
    /// Retrieve the roles assigned to a member invitation specified by ID for this Organization.
    /// </summary>
    WithRawResponseTask<GetMemberInvitationRolesResponseContent> ListAsync(
        string invitationId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
