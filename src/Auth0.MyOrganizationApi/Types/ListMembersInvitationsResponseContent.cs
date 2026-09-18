using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

[Serializable]
public record ListMembersInvitationsResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Pagination cursor for the next page of results.
    /// </summary>
    [Optional]
    [JsonPropertyName("next")]
    public string? Next { get; set; }

    /// <summary>
    /// Best-effort count of pending invitations in the result set (reflecting any active filters). Only present when include_totals=true. Capped at 1000.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [Optional]
    [JsonPropertyName("total")]
    public int? Total { get; set; }

    /// <summary>
    /// Whether counting stopped before reaching the true size of the result set. When true, 'total' is a lower bound (the true size is 'total' or greater); when false, 'total' reflects the full result set as counted. Only present when 'total' is present.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [Optional]
    [JsonPropertyName("total_is_capped")]
    public bool? TotalIsCapped { get; set; }

    [Optional]
    [JsonPropertyName("invitations")]
    public IEnumerable<MemberInvitation>? Invitations { get; set; }

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
