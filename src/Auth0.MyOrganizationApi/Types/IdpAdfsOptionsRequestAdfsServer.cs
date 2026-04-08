using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.MyOrganizationApi.Core;

namespace Auth0.MyOrganizationApi;

[Serializable]
public record IdpAdfsOptionsRequestAdfsServer : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The adfs_server is the public-facing URL that relying parties and internal clients use to communicate with an ADFS server for authentication and token issuance
    /// </summary>
    [JsonPropertyName("adfs_server")]
    public required string AdfsServer { get; set; }

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
