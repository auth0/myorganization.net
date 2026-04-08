using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.MyOrganizationApi.Core;

namespace Auth0.MyOrganizationApi;

/// <summary>
/// The organization config for identity providers.
/// </summary>
[Serializable]
public record IdentityProvidersConfigOrganization : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// If Org Admin can set show_as_button
    /// </summary>
    [JsonPropertyName("can_set_show_as_button")]
    public required bool CanSetShowAsButton { get; set; }

    /// <summary>
    /// If Org Admin can set assign_membership_on_login
    /// </summary>
    [JsonPropertyName("can_set_assign_membership_on_login")]
    public required bool CanSetAssignMembershipOnLogin { get; set; }

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
