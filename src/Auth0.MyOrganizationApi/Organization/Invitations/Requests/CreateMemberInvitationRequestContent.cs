using Auth0.MyOrganizationApi;
using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi.Organization;

[Serializable]
public record CreateMemberInvitationRequestContent
{
    [JsonIgnore]
    public string? Auth0CustomDomain { get; set; }

    [JsonPropertyName("invitees")]
    public IEnumerable<CreateMemberInvitationInvitee> Invitees { get; set; } =
        new List<CreateMemberInvitationInvitee>();

    [Optional]
    [JsonPropertyName("inviter")]
    public MemberInvitationInviter? Inviter { get; set; }

    /// <summary>
    /// Identity provider identifier.
    /// </summary>
    [Optional]
    [JsonPropertyName("identity_provider_id")]
    public string? IdentityProviderId { get; set; }

    /// <summary>
    /// Number of seconds for which the invitation is valid before expiration. If unspecified or set to 0, this value defaults to 604800 seconds (7 days). Max value: 2592000 seconds (30 days).
    /// </summary>
    [Optional]
    [JsonPropertyName("ttl_sec")]
    public int? TtlSec { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
