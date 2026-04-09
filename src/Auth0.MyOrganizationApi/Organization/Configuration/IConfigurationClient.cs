using Auth0.MyOrganizationApi;

namespace Auth0.MyOrganizationApi.Organization;

public partial interface IConfigurationClient
{
    public Auth0.MyOrganizationApi.Organization.Configuration.IIdentityProvidersClient IdentityProviders { get; }

    /// <summary>
    /// Retrieve the My Organization API configuration. Returns only the `connection_deletion_behavior` and `allowed_strategies`. Identifier attributes such as `user_attribute_profile_id` and `connection_profile_id` are not included. Cache this information, as it does not change frequently.
    /// </summary>
    WithRawResponseTask<GetConfigurationResponseContent> GetAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
