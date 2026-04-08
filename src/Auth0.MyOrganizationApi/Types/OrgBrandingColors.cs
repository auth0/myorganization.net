using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.MyOrganizationApi.Core;

namespace Auth0.MyOrganizationApi;

/// <summary>
/// Color scheme used to customize the login pages.
/// </summary>
[Serializable]
public record OrgBrandingColors : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// HEX Color for primary elements.
    /// </summary>
    [JsonPropertyName("primary")]
    public required string Primary { get; set; }

    /// <summary>
    /// HEX Color for background.
    /// </summary>
    [JsonPropertyName("page_background")]
    public required string PageBackground { get; set; }

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
