using Auth0.MyOrganizationApi;
using Auth0.MyOrganizationApi.Organization.IdentityProviders;

namespace Auth0.MyOrganizationApi.Organization;

public partial interface IIdentityProvidersClient
{
    public Auth0.MyOrganizationApi.Organization.IdentityProviders.IDomainsClient Domains { get; }
    public IProvisioningClient Provisioning { get; }

    /// <summary>
    /// Retrieve a list of all Identity Providers for this Organization.
    /// </summary>
    WithRawResponseTask<ListIdentityProvidersResponseContent> ListAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a new Identity Provider for this Organization.
    /// </summary>
    WithRawResponseTask<IdpKnownResponse> CreateAsync(
        IdpKnownRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve details of an Identity Provider specified by ID for this Organization.
    /// </summary>
    WithRawResponseTask<IdpKnownResponse> GetAsync(
        string idpId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete an Identity Provider specified by ID from this Organization. This will remove the association and delete the underlying Identity Provider. Members will no longer be able to authenticate using this Identity Provider.
    /// </summary>
    Task DeleteAsync(
        string idpId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update the details of an Identity Provider specified by ID for this Organization.
    /// </summary>
    WithRawResponseTask<IdpUpdateKnownResponse> UpdateAsync(
        string idpId,
        IdpUpdateKnownRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Refresh the attribute mapping for an Identity Provider specified by ID for this Organization. Mappings are reset to the admin-defined defaults.
    /// </summary>
    WithRawResponseTask<IdpKnownResponse> UpdateAttributesAsync(
        string idpId,
        Dictionary<string, object?> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove an Identity Provider specified by ID from this Organization. This only removes the association; the underlying Identity Provider is not deleted. Members will no longer be able to authenticate using this Identity Provider.
    /// </summary>
    Task DetachAsync(
        string idpId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
