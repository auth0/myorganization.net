using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

/// <summary>
/// Strategy-specific overrides for identity providers
/// </summary>
[Serializable]
public record IdentityProvidersConfigStrategyOverride : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("adfs")]
    public IdentityProvidersConfigStrategyBase? Adfs { get; set; }

    [Optional]
    [JsonPropertyName("googleapps")]
    public IdentityProvidersConfigStrategyBase? Googleapps { get; set; }

    [Optional]
    [JsonPropertyName("oidc")]
    public IdentityProvidersConfigStrategyBase? Oidc { get; set; }

    [Optional]
    [JsonPropertyName("okta")]
    public IdentityProvidersConfigStrategyBase? Okta { get; set; }

    [Optional]
    [JsonPropertyName("pingfederate")]
    public IdentityProvidersConfigStrategyBase? Pingfederate { get; set; }

    [Optional]
    [JsonPropertyName("samlp")]
    public IdentityProvidersConfigStrategyBase? Samlp { get; set; }

    [Optional]
    [JsonPropertyName("waad")]
    public IdentityProvidersConfigStrategyBase? Waad { get; set; }

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
