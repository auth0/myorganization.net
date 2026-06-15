using Auth0.MyOrganizationApi.Core;

namespace Auth0.MyOrganizationApi.Organization;

public partial class OrganizationClient : IOrganizationClient
{
    private readonly RawClient _client;

    internal OrganizationClient(RawClient client)
    {
        _client = client;
        Configuration = new ConfigurationClient(_client);
        Domains = new DomainsClient(_client);
        IdentityProviders = new IdentityProvidersClient(_client);
        Members = new MembersClient(_client);
        Memberships = new MembershipsClient(_client);
        Invitations = new InvitationsClient(_client);
        Roles = new RolesClient(_client);
    }

    public IConfigurationClient Configuration { get; }

    public IDomainsClient Domains { get; }

    public IIdentityProvidersClient IdentityProviders { get; }

    public IMembersClient Members { get; }

    public IMembershipsClient Memberships { get; }

    public IInvitationsClient Invitations { get; }

    public IRolesClient Roles { get; }
}
