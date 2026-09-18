using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi.Organization;

[Serializable]
public record ListMemberInvitationsRequestParameters
{
    /// <summary>
    /// Comma-separated list of fields to include or exclude (based on value provided for include_fields) in the result. Leave empty to retrieve all fields. Note: you cannot filter on ticket_id and this value will only be returned when fields are not filtered.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> Fields { get; set; }

    /// <summary>
    /// Whether specified fields are to be included (true) or excluded (false). Defaults to true
    /// </summary>
    [JsonIgnore]
    public Optional<bool?> IncludeFields { get; set; } = true;

    /// <summary>
    /// An optional cursor from which to start the selection (exclusive).
    /// </summary>
    [JsonIgnore]
    public Optional<string?> From { get; set; }

    /// <summary>
    /// Number of results per page. Defaults to 50.
    /// </summary>
    [JsonIgnore]
    public Optional<int?> Take { get; set; } = 50;

    /// <summary>
    /// Field to sort by. Use field:order where order is 1 for ascending and -1 for descending. Defaults to created_at:-1
    /// </summary>
    [JsonIgnore]
    public Optional<string?> Sort { get; set; } = "created_at:-1";

    /// <summary>
    /// When true, the response includes a 'total' count of items in the result set (reflecting any active filters), along with a 'total_is_capped' flag. The count is best-effort and capped at 1000; when the true size may be larger, 'total_is_capped' is true and 'total' is a lower bound. Omitted when not requested.
    /// </summary>
    [JsonIgnore]
    public Optional<bool?> IncludeTotals { get; set; } = false;

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
