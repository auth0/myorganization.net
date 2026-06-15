using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi.Organization;

[Serializable]
public record ListRolesRequestParameters
{
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
    /// An optional filter on the name (case-insensitive).
    /// </summary>
    [JsonIgnore]
    public Optional<string?> Name { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
