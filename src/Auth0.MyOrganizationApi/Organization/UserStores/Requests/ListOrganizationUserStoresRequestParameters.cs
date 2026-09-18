using Auth0.MyOrganizationApi;
using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi.Organization;

[Serializable]
public record ListOrganizationUserStoresRequestParameters
{
    /// <summary>
    /// When present, only connections whose Organization Member Access Level matches one of the provided values are returned. Accepted values are full, limited, readonly and none.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<OrganizationAccessLevelEnum?> MemberAccessLevel { get; set; } =
        new List<OrganizationAccessLevelEnum?>();

    /// <summary>
    /// Filter the returned list by enabled status. When `true`, only enabled items are returned; when `false`, only disabled items; when omitted, all items are returned.
    /// </summary>
    [JsonIgnore]
    public Optional<bool?> IsEnabled { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
