using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

[Serializable]
public record MemberInvitation : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonAccess(JsonAccessType.ReadOnly)]
    [Optional]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonAccess(JsonAccessType.ReadOnly)]
    [Optional]
    [JsonPropertyName("organization_id")]
    public string? OrganizationId { get; set; }

    [Optional]
    [JsonPropertyName("inviter")]
    public MemberInvitationInviter? Inviter { get; set; }

    [Optional]
    [JsonPropertyName("invitee")]
    public MemberInvitationInvitee? Invitee { get; set; }

    [JsonAccess(JsonAccessType.ReadOnly)]
    [Optional]
    [JsonPropertyName("identity_provider_id")]
    public string? IdentityProviderId { get; set; }

    /// <summary>
    /// The ISO 8601 formatted timestamp representing the creation time of the invitation.
    /// </summary>
    [Optional]
    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// The ISO 8601 formatted timestamp representing the expiration time of the invitation.
    /// </summary>
    [Optional]
    [JsonPropertyName("expires_at")]
    public DateTime? ExpiresAt { get; set; }

    [JsonAccess(JsonAccessType.ReadOnly)]
    [Optional]
    [JsonPropertyName("roles")]
    public IEnumerable<string>? Roles { get; set; }

    /// <summary>
    /// The invitation url to be sent to the invitee.
    /// </summary>
    [Optional]
    [JsonPropertyName("invitation_url")]
    public string? InvitationUrl { get; set; }

    /// <summary>
    /// The ID of the invitation ticket.
    /// </summary>
    [Optional]
    [JsonPropertyName("ticket_id")]
    public string? TicketId { get; set; }

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
