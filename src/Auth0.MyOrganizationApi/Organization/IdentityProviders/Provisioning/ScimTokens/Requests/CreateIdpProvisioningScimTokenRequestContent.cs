using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi.Organization.IdentityProviders.Provisioning;

[Serializable]
public record CreateIdpProvisioningScimTokenRequestContent
{
    /// <summary>
    /// Lifetime of the token in seconds. Do not set for non-expiring tokens.
    /// </summary>
    [Optional]
    [JsonPropertyName("token_lifetime")]
    public int? TokenLifetime { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
