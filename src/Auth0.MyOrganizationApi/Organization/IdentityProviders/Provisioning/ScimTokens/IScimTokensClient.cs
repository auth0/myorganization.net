using Auth0.MyOrganizationApi;

namespace Auth0.MyOrganizationApi.Organization.IdentityProviders.Provisioning;

public partial interface IScimTokensClient
{
    /// <summary>
    /// Retrieve a list of [SCIM tokens](https://auth0.com/docs/authenticate/protocols/scim/configure-inbound-scim#scim-endpoints-and-tokens) for the Provisioning Configuration of an Identity Provider specified by ID for this Organization.
    /// </summary>
    WithRawResponseTask<ListIdpProvisioningScimTokensResponseContent> ListAsync(
        string idpId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a new SCIM token for the Provisioning Configuration of an Identity Provider specified by ID for this Organization.
    /// </summary>
    WithRawResponseTask<IdpScimTokenCreate> CreateAsync(
        string idpId,
        CreateIdpProvisioningScimTokenRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Revoke a SCIM token specified by token ID for the Provisioning Configuration of an Identity Provider specified by ID for this Organization.
    /// </summary>
    Task DeleteAsync(
        string idpId,
        string idpScimTokenId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
