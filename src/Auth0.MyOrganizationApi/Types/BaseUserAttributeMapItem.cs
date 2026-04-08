using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.MyOrganizationApi.Core;

namespace Auth0.MyOrganizationApi;

[Serializable]
public record BaseUserAttributeMapItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The name of the user attribute.
    /// </summary>
    [JsonPropertyName("user_attribute")]
    public required string UserAttribute { get; set; }

    /// <summary>
    /// The description of the user attribute.
    /// </summary>
    [Optional]
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The label of the user attribute.
    /// </summary>
    [Optional]
    [JsonPropertyName("label")]
    public string? Label { get; set; }

    /// <summary>
    /// Indicates if the attribute is required.
    /// </summary>
    [JsonPropertyName("is_required")]
    public required bool IsRequired { get; set; }

    /// <summary>
    /// Indicates whether this attribute is not part of the admin defined schema but is provided by the source. The property will be removed when a refresh operation is performed.
    /// </summary>
    [JsonPropertyName("is_extra")]
    public required bool IsExtra { get; set; }

    /// <summary>
    /// Indicates whether this attribute is expected but not provided by the admin defined schema. The property will   be added when a refresh operation is performed.
    /// </summary>
    [JsonPropertyName("is_missing")]
    public required bool IsMissing { get; set; }

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
