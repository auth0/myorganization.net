using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

/// <summary>
/// Identity provider specific options.
/// </summary>
[Serializable]
public record IdpAdfsRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("strategy")]
    public required IdpAdfsRequestStrategy Strategy { get; set; }

    /// <summary>
    /// Identity provider specific options.
    /// </summary>
    [JsonPropertyName("options")]
    public required IdpAdfsOptionsRequest Options { get; set; }

    [Optional]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The name of the identity provider
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// List of domains for Home Realm Discovery (HRD)
    /// </summary>
    [Optional]
    [JsonPropertyName("domains")]
    public IEnumerable<string>? Domains { get; set; }

    /// <summary>
    /// Identity provider name used on the login screen.
    /// </summary>
    [Optional]
    [JsonPropertyName("display_name")]
    public string? DisplayName { get; set; }

    /// <summary>
    /// Enables showing a button for the connection in the login page (new experience only). If false, it will be usable only by Home Realm Discovery (HRD).
    /// </summary>
    [Optional]
    [JsonPropertyName("show_as_button")]
    public bool? ShowAsButton { get; set; }

    /// <summary>
    /// If true, the user will be made a member of the organization upon login.
    /// </summary>
    [Optional]
    [JsonPropertyName("assign_membership_on_login")]
    public bool? AssignMembershipOnLogin { get; set; }

    /// <summary>
    /// True if the identity provider is enabled for the organization.
    /// </summary>
    [Optional]
    [JsonPropertyName("is_enabled")]
    public bool? IsEnabled { get; set; }

    [Optional]
    [JsonPropertyName("access_level")]
    public OrganizationAccessLevelEnum? AccessLevel { get; set; }

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
