using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.MyOrganizationApi.Core;

namespace Auth0.MyOrganizationApi;

[Serializable]
public record IdpScimTokenBase : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The token identifier.
    /// </summary>
    [JsonPropertyName("token_id")]
    public required string TokenId { get; set; }

    /// <summary>
    /// The token's scopes.
    /// </summary>
    [Optional]
    [JsonPropertyName("scopes")]
    public IEnumerable<string>? Scopes { get; set; }

    /// <summary>
    /// The token's created at timestamp.
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// The token's valid until at timestamp (will not exist for non-expiring tokens).
    /// </summary>
    [Optional]
    [JsonPropertyName("valid_until")]
    public DateTime? ValidUntil { get; set; }

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
