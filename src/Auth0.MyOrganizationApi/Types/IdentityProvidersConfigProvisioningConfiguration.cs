using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

/// <summary>
/// The provisioning configuration supported by the identity provider
/// </summary>
[Serializable]
public record IdentityProvidersConfigProvisioningConfiguration : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("on_login")]
    public IdentityProvidersConfigProvisioningConfigurationOnLogin? OnLogin { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("scim")]
    public Optional<IdentityProvidersConfigProvisioningConfigurationScim?> Scim { get; set; }

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
