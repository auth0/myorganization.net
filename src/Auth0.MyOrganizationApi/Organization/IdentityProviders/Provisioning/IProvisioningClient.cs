using Auth0.MyOrganizationApi;
using Auth0.MyOrganizationApi.Organization.IdentityProviders.Provisioning;

namespace Auth0.MyOrganizationApi.Organization.IdentityProviders;

public partial interface IProvisioningClient
{
    public IScimTokensClient ScimTokens { get; }

    /// <summary>
    /// Retrieve the Provisioning configuration for this identity provider.
    /// </summary>
    WithRawResponseTask<GetIdPProvisioningConfigResponseContent> GetAsync(
        string idpId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create the Provisioning configuration for this identity provider.
    /// </summary>
    WithRawResponseTask<CreateIdPProvisioningConfigResponseContent> CreateAsync(
        string idpId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete the Provisioning configuration for an identity provider.
    /// </summary>
    Task DeleteAsync(
        string idpId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Triggers a refresh of attribute mappings on the provisioning configuration by overriding it with the admin defined defaults. The endpoint doesn't accept any body parameters.
    /// </summary>
    WithRawResponseTask<GetIdPProvisioningConfigResponseContent> UpdateAttributesAsync(
        string idpId,
        Dictionary<string, object?> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
