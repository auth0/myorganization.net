namespace Auth0.MyOrganizationApi;

public partial interface IOrganizationDetailsClient
{
    /// <summary>
    /// Retrieve details for an Organization.
    /// </summary>
    WithRawResponseTask<OrgDetailsRead> GetAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update the details of a specific Organization, such as display name and branding options.
    /// </summary>
    WithRawResponseTask<OrgDetailsRead> UpdateAsync(
        OrgDetails request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
