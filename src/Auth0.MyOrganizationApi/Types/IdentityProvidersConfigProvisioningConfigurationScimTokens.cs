using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

[Serializable]
public record IdentityProvidersConfigProvisioningConfigurationScimTokens : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("scopes")]
    public IEnumerable<IdentityProvidersConfigProvisioningConfigurationScimTokensScopesEnum>? Scopes { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("default_expiry")]
    public Optional<int?> DefaultExpiry { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("max_allowed_expiry")]
    public Optional<int?> MaxAllowedExpiry { get; set; }

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
