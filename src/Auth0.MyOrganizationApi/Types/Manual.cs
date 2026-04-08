using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.MyOrganizationApi.Core;

namespace Auth0.MyOrganizationApi;

[Serializable]
public record Manual : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The endpoint URL for the IdP sign-in
    /// </summary>
    [Optional]
    [JsonPropertyName("signInEndpoint")]
    public string? SignInEndpoint { get; set; }

    /// <summary>
    /// Signing certificate (encoded in PEM or CER) you retrieved from the IdP
    /// </summary>
    [Optional]
    [JsonPropertyName("cert")]
    public string? Cert { get; set; }

    /// <summary>
    /// When enabled, the SAML authentication request will be signed.
    /// </summary>
    [Optional]
    [JsonPropertyName("signSAMLRequest")]
    public bool? SignSamlRequest { get; set; }

    [Optional]
    [JsonPropertyName("signatureAlgorithm")]
    public IdpSignAlgTypeEnum? SignatureAlgorithm { get; set; }

    [Optional]
    [JsonPropertyName("digestAlgorithm")]
    public IdpSignAlgDigestTypeEnum? DigestAlgorithm { get; set; }

    [Optional]
    [JsonPropertyName("protocolBinding")]
    public IdpProtocolBindingTypeEnum? ProtocolBinding { get; set; }

    /// <summary>
    /// Defines the specific HTTP binding used for sending SAML messages.
    /// </summary>
    [Optional]
    [JsonPropertyName("bindingMethod")]
    public string? BindingMethod { get; set; }

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
