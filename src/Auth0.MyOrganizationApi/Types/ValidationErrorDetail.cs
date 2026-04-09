using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

[Serializable]
public record ValidationErrorDetail : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A detailed description of the error.
    /// </summary>
    [JsonPropertyName("detail")]
    public required string Detail { get; set; }

    /// <summary>
    /// The name of the invalid parameter.
    /// </summary>
    [Optional]
    [JsonPropertyName("field")]
    public string? Field { get; set; }

    /// <summary>
    /// JSON Pointer that points to the exact location of the error in a JSON document being validated.
    /// </summary>
    [Optional]
    [JsonPropertyName("pointer")]
    public string? Pointer { get; set; }

    /// <summary>
    /// Specifies the source of the error (e.g., body, query, or header in an HTML message).
    /// </summary>
    [Optional]
    [JsonPropertyName("source")]
    public string? Source { get; set; }

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
