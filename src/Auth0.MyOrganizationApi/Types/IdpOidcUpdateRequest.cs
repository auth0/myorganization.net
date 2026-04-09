using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

/// <summary>
/// Identity provider specific options.  Requires access_level to be 'full'.
/// </summary>
[Serializable]
public record IdpOidcUpdateRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Identity provider specific options.  Requires access_level to be 'full'.
    /// </summary>
    [Optional]
    [JsonPropertyName("options")]
    public IdpOidcOptionsRequest? Options { get; set; }

    /// <summary>
    /// Identity provider name used on the login screen. Requires access_level to be 'full'
    /// </summary>
    [Optional]
    [JsonPropertyName("display_name")]
    public string? DisplayName { get; set; }

    /// <summary>
    /// Enables showing a button for the connection in the login page (new experience only). If false, it will be usable only by Home Realm Discovery (HRD). Requires access_level to be 'full' or 'limited'
    /// </summary>
    [Optional]
    [JsonPropertyName("show_as_button")]
    public bool? ShowAsButton { get; set; }

    /// <summary>
    /// If true, the user will be made a member of the organization upon login. Requires access_level to be 'full' or 'limited'.
    /// </summary>
    [Optional]
    [JsonPropertyName("assign_membership_on_login")]
    public bool? AssignMembershipOnLogin { get; set; }

    /// <summary>
    /// True if the identity provider is enabled for the organization. Requires access_level to be 'full' or 'limited'
    /// </summary>
    [Optional]
    [JsonPropertyName("is_enabled")]
    public bool? IsEnabled { get; set; }

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
