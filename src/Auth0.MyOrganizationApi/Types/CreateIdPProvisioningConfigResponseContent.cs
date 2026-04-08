using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.MyOrganizationApi.Core;

namespace Auth0.MyOrganizationApi;

[Serializable]
public record CreateIdPProvisioningConfigResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_on")]
    public required DateTime UpdatedOn { get; set; }

    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("identity_provider_id")]
    public string IdentityProviderId { get; set; }

    /// <summary>
    /// The name of the identity provider
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("identity_provider_name")]
    public string IdentityProviderName { get; set; }

    [JsonPropertyName("strategy")]
    public required IdpStrategyEnum Strategy { get; set; }

    [JsonPropertyName("method")]
    public required IdpProvisioningMethodEnum Method { get; set; }

    [JsonPropertyName("attributes")]
    public IEnumerable<IdpProvisioningUserAttributeMapItem> Attributes { get; set; } =
        new List<IdpProvisioningUserAttributeMapItem>();

    /// <summary>
    /// The ID of the user
    /// </summary>
    [JsonPropertyName("user_id_attribute")]
    public required string UserIdAttribute { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
