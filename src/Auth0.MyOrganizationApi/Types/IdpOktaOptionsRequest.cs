using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.MyOrganizationApi.Core;

namespace Auth0.MyOrganizationApi;

[Serializable]
public record IdpOktaOptionsRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Okta's domain name for your organization.
    /// </summary>
    [JsonPropertyName("domain")]
    public required string Domain { get; set; }

    /// <summary>
    /// Unique identifier for your registered Okta application
    /// </summary>
    [JsonPropertyName("client_id")]
    public required string ClientId { get; set; }

    /// <summary>
    /// String used to gain access to your registered Okta application.
    /// </summary>
    [JsonPropertyName("client_secret")]
    public required string ClientSecret { get; set; }

    /// <summary>
    /// A URL pointing to an image file that represents your client application.
    /// </summary>
    [Optional]
    [JsonPropertyName("icon_url")]
    public string? IconUrl { get; set; }

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
