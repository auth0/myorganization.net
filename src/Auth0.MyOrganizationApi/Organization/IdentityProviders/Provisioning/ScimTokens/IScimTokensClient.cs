using Auth0.MyOrganizationApi;

namespace Auth0.MyOrganizationApi.Organization.IdentityProviders.Provisioning;

public partial interface IScimTokensClient
{
    /// <summary>
    /// List the Provisioning SCIM tokens for this identity provider.
    /// </summary>
    WithRawResponseTask<ListIdpProvisioningScimTokensResponseContent> ListAsync(
        string idpId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a Provisioning SCIM token for this identity provider.
    /// </summary>
    WithRawResponseTask<IdpScimTokenCreate> CreateAsync(
        string idpId,
        CreateIdpProvisioningScimTokenRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a Provisioning SCIM configuration for an identity provider.
    /// </summary>
    Task DeleteAsync(
        string idpId,
        string idpScimTokenId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
