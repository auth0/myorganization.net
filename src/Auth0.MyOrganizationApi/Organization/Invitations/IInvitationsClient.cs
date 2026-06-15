using Auth0.MyOrganizationApi;
using Auth0.MyOrganizationApi.Core;

namespace Auth0.MyOrganizationApi.Organization;

public partial interface IInvitationsClient
{
    /// <summary>
    /// Retrieve a list of all member invitations for this Organization.
    /// </summary>
    Task<Pager<MemberInvitation>> ListAsync(
        ListMemberInvitationsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create one or more member invitations for this Organization. If an active invitation already exists for a user, generating a new invitation will automatically revoke any outstanding invitations for that user. Roles specified in the payload will be granted to the user upon acceptance of the invitation.
    /// </summary>
    WithRawResponseTask<IEnumerable<MemberInvitation>> CreateAsync(
        CreateMemberInvitationRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve details of a member invitation specified by ID for this Organization.
    /// </summary>
    WithRawResponseTask<MemberInvitation> GetAsync(
        string invitationId,
        GetMemberInvitationRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Revoke a member invitation specified by ID for this Organization.
    /// </summary>
    Task DeleteAsync(
        string invitationId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
