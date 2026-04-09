using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

[Serializable]
public record OrgMember : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonAccess(JsonAccessType.ReadOnly)]
    [Optional]
    [JsonPropertyName("user_id")]
    public string? UserId { get; set; }

    [JsonAccess(JsonAccessType.ReadOnly)]
    [Optional]
    [JsonPropertyName("roles")]
    public IEnumerable<OrgMemberRole>? Roles { get; set; }

    /// <summary>
    /// Date and time when this user was created (ISO_8601 format).
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [Optional]
    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// Date and time when this user was last updated (ISO_8601 format).
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [Optional]
    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Last date and time this user logged in (ISO_8601 format).
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [Optional]
    [JsonPropertyName("last_login")]
    public DateTime? LastLogin { get; set; }

    /// <summary>
    /// Email
    /// </summary>
    [Optional]
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// Full Name
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// User nickname
    /// </summary>
    [Optional]
    [JsonPropertyName("nickname")]
    public string? Nickname { get; set; }

    /// <summary>
    /// First name
    /// </summary>
    [Optional]
    [JsonPropertyName("given_name")]
    public string? GivenName { get; set; }

    /// <summary>
    /// Last name
    /// </summary>
    [Optional]
    [JsonPropertyName("family_name")]
    public string? FamilyName { get; set; }

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
