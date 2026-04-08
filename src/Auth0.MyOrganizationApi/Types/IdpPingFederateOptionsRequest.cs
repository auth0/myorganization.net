using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.MyOrganizationApi.Core;

namespace Auth0.MyOrganizationApi;

[Serializable]
public record IdpPingFederateOptionsRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("signatureAlgorithm")]
    public required IdpSignAlgTypeEnum SignatureAlgorithm { get; set; }

    [JsonPropertyName("digestAlgorithm")]
    public required IdpSignAlgDigestTypeEnum DigestAlgorithm { get; set; }

    /// <summary>
    /// Indicates whether PingFederate should digitally sign outgoing SAML authentication requests to relying parties
    /// </summary>
    [JsonPropertyName("signSAMLRequest")]
    public required bool SignSamlRequest { get; set; }

    /// <summary>
    /// URL provided by PingFederate which returns information used for creating the connection
    /// </summary>
    [JsonPropertyName("pingFederateBaseUrl")]
    public required string PingFederateBaseUrl { get; set; }

    /// <summary>
    /// PingFederate Server public key (encoded in PEM or CER) you retrieved from the IdP
    /// </summary>
    [JsonPropertyName("signingCert")]
    public required string SigningCert { get; set; }

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
