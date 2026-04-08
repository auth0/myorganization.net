using Auth0.MyOrganizationApi.Organization;

namespace Auth0.MyOrganizationApi;

public partial interface IMyOrganizationApiClient
{
    public IOrganizationDetailsClient OrganizationDetails { get; }
    public IOrganizationClient Organization { get; }
}
