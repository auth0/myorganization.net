using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.MyOrganizationApi.Core;

namespace Auth0.MyOrganizationApi;

[Serializable]
public record IdpPingFederateOptionsResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("signatureAlgorithm")]
    public IdpSignAlgTypeEnum? SignatureAlgorithm { get; set; }

    [Optional]
    [JsonPropertyName("digestAlgorithm")]
    public IdpSignAlgDigestTypeEnum? DigestAlgorithm { get; set; }

    /// <summary>
    /// Indicates whether PingFederate should digitally sign outgoing SAML authentication requests to relying parties
    /// </summary>
    [Optional]
    [JsonPropertyName("signSAMLRequest")]
    public bool? SignSamlRequest { get; set; }

    /// <summary>
    /// URL provided by PingFederate which returns information used for creating the connection
    /// </summary>
    [Optional]
    [JsonPropertyName("pingFederateBaseUrl")]
    public string? PingFederateBaseUrl { get; set; }

    /// <summary>
    /// A value derived from decoding the signingCert. This should not be updated directly, instead update the signingCertificate to decode a new value for this field
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [Optional]
    [JsonPropertyName("cert")]
    public string? Cert { get; set; }

    [Optional]
    [JsonPropertyName("idpInitiated")]
    public IdpOptionsIdpInitiated? IdpInitiated { get; set; }

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
