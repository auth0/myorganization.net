using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.MyOrganizationApi.Core;

namespace Auth0.MyOrganizationApi;

/// <summary>
/// Identity providers strategy configs
/// </summary>
[Serializable]
public record IdentityProvidersConfigStrategyBase : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Enabled features for a connections profile strategy override.
    /// </summary>
    [JsonPropertyName("enabled_features")]
    public IEnumerable<IdentityProvidersConfigEnabledFeaturesEnum> EnabledFeatures { get; set; } =
        new List<IdentityProvidersConfigEnabledFeaturesEnum>();

    [JsonPropertyName("provisioning_methods")]
    public IEnumerable<IdentityProvidersConfigProvisioningMethodsEnum> ProvisioningMethods { get; set; } =
        new List<IdentityProvidersConfigProvisioningMethodsEnum>();

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
