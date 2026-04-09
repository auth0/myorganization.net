namespace Auth0.MyOrganizationApi;

public partial interface IOrganizationDetailsClient
{
    /// <summary>
    /// Retrieve details for this Organization, including display name and branding options. To learn more about Auth0 Organizations, read [Organizations](https://auth0.com/docs/manage-users/organizations).
    /// </summary>
    WithRawResponseTask<OrgDetailsRead> GetAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update details for this Organization, such as display name and branding options. To learn more about Auth0 Organizations, read [Organizations](https://auth0.com/docs/manage-users/organizations).
    /// </summary>
    WithRawResponseTask<OrgDetailsRead> UpdateAsync(
        OrgDetails request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
