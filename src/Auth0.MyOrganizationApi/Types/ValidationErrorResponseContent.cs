using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

[Serializable]
public record ValidationErrorResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A URI that describes the error.
    /// </summary>
    [JsonPropertyName("type")]
    public required string Type { get; set; }

    /// <summary>
    /// The HTTP status code result of the request.
    /// </summary>
    [JsonPropertyName("status")]
    public required int Status { get; set; }

    /// <summary>
    /// A brief description of the error.
    /// </summary>
    [JsonPropertyName("title")]
    public required string Title { get; set; }

    [JsonPropertyName("validation_errors")]
    public IEnumerable<ValidationErrorDetail> ValidationErrors { get; set; } =
        new List<ValidationErrorDetail>();

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
