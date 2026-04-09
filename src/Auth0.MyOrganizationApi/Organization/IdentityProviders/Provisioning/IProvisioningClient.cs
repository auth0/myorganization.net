using Auth0.MyOrganizationApi;
using Auth0.MyOrganizationApi.Organization.IdentityProviders.Provisioning;

namespace Auth0.MyOrganizationApi.Organization.IdentityProviders;

public partial interface IProvisioningClient
{
    public IScimTokensClient ScimTokens { get; }

    /// <summary>
    /// Retrieve the Provisioning Configuration for an Identity Provider specified by ID for this Organization.
    /// </summary>
    WithRawResponseTask<GetIdPProvisioningConfigResponseContent> GetAsync(
        string idpId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a new Provisioning Configuration for an Identity Provider specified by ID for this Organization.
    /// </summary>
    WithRawResponseTask<CreateIdPProvisioningConfigResponseContent> CreateAsync(
        string idpId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete the Provisioning Configuration for an Identity Provider specified by ID for this Organization.
    /// </summary>
    Task DeleteAsync(
        string idpId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Refresh the attribute mapping for the Provisioning Configuration of an Identity Provider specified by ID for this Organization. Mappings are reset to the admin-defined defaults.
    /// </summary>
    WithRawResponseTask<GetIdPProvisioningConfigResponseContent> UpdateAttributesAsync(
        string idpId,
        Dictionary<string, object?> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
