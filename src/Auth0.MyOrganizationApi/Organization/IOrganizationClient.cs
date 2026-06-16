namespace Auth0.MyOrganizationApi.Organization;

public partial interface IOrganizationClient
{
    public IConfigurationClient Configuration { get; }
    public IDomainsClient Domains { get; }
    public IIdentityProvidersClient IdentityProviders { get; }
    public IMembersClient Members { get; }
    public IMembershipsClient Memberships { get; }
    public IInvitationsClient Invitations { get; }
    public IRolesClient Roles { get; }
}
