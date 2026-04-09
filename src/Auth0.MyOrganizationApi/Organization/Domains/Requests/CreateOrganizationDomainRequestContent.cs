using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi.Organization;

[Serializable]
public record CreateOrganizationDomainRequestContent
{
    [JsonPropertyName("domain")]
    public required string Domain { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
