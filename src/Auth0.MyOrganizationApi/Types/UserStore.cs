using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

[Serializable]
public record UserStore : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// User store Id
    /// </summary>
    [Optional]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// User store name
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// User store display name
    /// </summary>
    [Optional]
    [JsonPropertyName("display_name")]
    public string? DisplayName { get; set; }

    [Optional]
    [JsonPropertyName("access_level")]
    public OrganizationAccessLevelEnum? AccessLevel { get; set; }

    /// <summary>
    /// The Organization Member Access Level for this user store: what the Organization Admin can do to members authenticated via this connection.
    /// </summary>
    [Optional]
    [JsonPropertyName("member_access_level")]
    public OrganizationMemberAccessLevelEnum? MemberAccessLevel { get; set; }

    /// <summary>
    /// Is the user store enabled
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
