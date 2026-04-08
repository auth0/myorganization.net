using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.MyOrganizationApi.Core;

namespace Auth0.MyOrganizationApi;

/// <summary>
/// An object containing configuration details for Identity Provider (IdP) initiated single sign-on flows
/// </summary>
[Serializable]
public record IdpOptionsIdpInitiated : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A flag indicating whether IdP-initiated SSO is enabled for this connection
    /// </summary>
    [Optional]
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// The client ID of your default application for which the IdP-initiated flow is being configured
    /// </summary>
    [Optional]
    [JsonPropertyName("client_id")]
    public string? ClientId { get; set; }

    /// <summary>
    /// This is the protocol used to connect your selected default application
    /// </summary>
    [Optional]
    [JsonPropertyName("client_protocol")]
    public string? ClientProtocol { get; set; }

    /// <summary>
    /// This field represents a template for constructing the authorization query string when initiating an IdP-initiated flow to a specific client
    /// </summary>
    [Optional]
    [JsonPropertyName("client_authorizequery")]
    public string? ClientAuthorizequery { get; set; }

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
