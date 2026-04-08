using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.MyOrganizationApi.Core;

namespace Auth0.MyOrganizationApi;

/// <summary>
/// Theme defines how to style the login pages.
/// </summary>
[Serializable]
public record OrgBranding : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// URL of logo to display on login page.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("logo_url")]
    public Optional<string?> LogoUrl { get; set; }

    [Optional]
    [JsonPropertyName("colors")]
    public OrgBrandingColors? Colors { get; set; }

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
