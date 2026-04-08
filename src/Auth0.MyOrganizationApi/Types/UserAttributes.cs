using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.MyOrganizationApi.Core;

namespace Auth0.MyOrganizationApi;

[Serializable]
public record UserAttributes : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Email
    /// </summary>
    [Optional]
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// Full Name
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// User nickname
    /// </summary>
    [Optional]
    [JsonPropertyName("nickname")]
    public string? Nickname { get; set; }

    /// <summary>
    /// First name
    /// </summary>
    [Optional]
    [JsonPropertyName("given_name")]
    public string? GivenName { get; set; }

    /// <summary>
    /// Last name
    /// </summary>
    [Optional]
    [JsonPropertyName("family_name")]
    public string? FamilyName { get; set; }

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
