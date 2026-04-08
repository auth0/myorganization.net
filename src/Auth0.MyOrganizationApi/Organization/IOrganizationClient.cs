namespace Auth0.MyOrganizationApi.Organization;

public partial interface IOrganizationClient
{
    public IConfigurationClient Configuration { get; }
    public IDomainsClient Domains { get; }
    public IIdentityProvidersClient IdentityProviders { get; }
}
