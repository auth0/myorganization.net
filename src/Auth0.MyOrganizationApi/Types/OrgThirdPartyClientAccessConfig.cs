using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

/// <summary>
/// Configuration for third-party client access
/// </summary>
[Serializable]
public record OrgThirdPartyClientAccessConfig : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("default_value")]
    public required OrgThirdPartyClientAccessEnum DefaultValue { get; set; }

    /// <summary>
    /// Allowed third-party client access values
    /// </summary>
    [JsonPropertyName("allowed_values")]
    public IEnumerable<OrgThirdPartyClientAccessEnum> AllowedValues { get; set; } =
        new List<OrgThirdPartyClientAccessEnum>();

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
