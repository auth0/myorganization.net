using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.MyOrganizationApi.Core;

namespace Auth0.MyOrganizationApi;

[Serializable]
public record OrgDomain : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("org_id")]
    public string OrgId { get; set; }

    [JsonPropertyName("domain")]
    public required string Domain { get; set; }

    [JsonPropertyName("status")]
    public required OrgDomainStatusEnum Status { get; set; }

    /// <summary>
    /// Value used to verify the domain.
    /// </summary>
    [JsonPropertyName("verification_txt")]
    public required string VerificationTxt { get; set; }

    /// <summary>
    /// Stores the full domain where the TXT record should be added.
    /// </summary>
    [JsonPropertyName("verification_host")]
    public required string VerificationHost { get; set; }

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
