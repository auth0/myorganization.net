using System.Text.Json.Serialization;
using Auth0.MyOrganizationApi.Core;

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
