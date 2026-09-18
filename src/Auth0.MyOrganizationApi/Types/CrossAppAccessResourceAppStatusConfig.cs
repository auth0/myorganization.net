using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

[Serializable]
public record CrossAppAccessResourceAppStatusConfig : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The value applied to `cross_app_access_resource_app.status` when an identity provider is created and no other value is specified.
    /// </summary>
    [JsonPropertyName("default_value")]
    public required CrossAppAccessResourceAppStatusConfigEnum DefaultValue { get; set; }

    /// <summary>
    /// A list of values, other than `default_value`, that may be set for `cross_app_access_resource_app.status` when creating or updating an identity provider. If omitted, only `default_value` is permitted.
    /// </summary>
    [Optional]
    [JsonPropertyName("allowed_values")]
    public IEnumerable<CrossAppAccessResourceAppStatusConfigEnum>? AllowedValues { get; set; }

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
