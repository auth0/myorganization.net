using Auth0.MyOrganizationApi;
using Auth0.MyOrganizationApi.Organization.IdentityProviders;

namespace Auth0.MyOrganizationApi.Organization;

public partial interface IIdentityProvidersClient
{
    public Auth0.MyOrganizationApi.Organization.IdentityProviders.IDomainsClient Domains { get; }
    public IProvisioningClient Provisioning { get; }

    /// <summary>
    /// List the identity providers associated with this organization.
    /// </summary>
    WithRawResponseTask<ListIdentityProvidersResponseContent> ListAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create an identity provider associated with this organization.
    /// </summary>
    WithRawResponseTask<IdpKnownResponse> CreateAsync(
        IdpKnownRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve the details for one particular identity-provider.
    /// </summary>
    WithRawResponseTask<IdpKnownResponse> GetAsync(
        string idpId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete an identity provider from this organization.
    /// </summary>
    Task DeleteAsync(
        string idpId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update an identity provider associated with this organization.
    /// </summary>
    WithRawResponseTask<IdpUpdateKnownResponse> UpdateAsync(
        string idpId,
        IdpUpdateKnownRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Triggers a refresh of attribute mappings on the identity provider by overriding it with the admin defined defaults. The endpoint doesn't accept any body parameters.
    /// </summary>
    WithRawResponseTask<IdpKnownResponse> UpdateAttributesAsync(
        string idpId,
        Dictionary<string, object?> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete underlying identity provider from this organization.
    /// </summary>
    Task DetachAsync(
        string idpId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
