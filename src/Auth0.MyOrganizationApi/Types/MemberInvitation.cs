using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.MyOrganizationApi.Core;

namespace Auth0.MyOrganizationApi;

[Serializable]
public record MemberInvitation : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("organization_id")]
    public string OrganizationId { get; set; }

    [JsonPropertyName("inviter")]
    public required MemberInvitationInviter Inviter { get; set; }

    [JsonPropertyName("invitee")]
    public required MemberInvitationInvitee Invitee { get; set; }

    [JsonAccess(JsonAccessType.ReadOnly)]
    [Optional]
    [JsonPropertyName("identity_provider_id")]
    public string? IdentityProviderId { get; set; }

    /// <summary>
    /// The ISO 8601 formatted timestamp representing the creation time of the invitation.
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// The ISO 8601 formatted timestamp representing the expiration time of the invitation.
    /// </summary>
    [JsonPropertyName("expires_at")]
    public required DateTime ExpiresAt { get; set; }

    [Optional]
    [JsonPropertyName("roles")]
    public IEnumerable<string>? Roles { get; set; }

    /// <summary>
    /// The invitation url to be sent to the invitee.
    /// </summary>
    [JsonPropertyName("invitation_url")]
    public required string InvitationUrl { get; set; }

    /// <summary>
    /// The ID of the invitation ticket.
    /// </summary>
    [JsonPropertyName("ticket_id")]
    public required string TicketId { get; set; }

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
