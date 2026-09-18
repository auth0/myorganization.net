using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

[JsonConverter(
    typeof(IdentityProvidersConfigProvisioningConfigurationScimTokensScopesEnum.IdentityProvidersConfigProvisioningConfigurationScimTokensScopesEnumSerializer)
)]
[Serializable]
public readonly record struct IdentityProvidersConfigProvisioningConfigurationScimTokensScopesEnum
    : IStringEnum
{
    public static readonly IdentityProvidersConfigProvisioningConfigurationScimTokensScopesEnum GetUsers =
        new(Values.GetUsers);

    public static readonly IdentityProvidersConfigProvisioningConfigurationScimTokensScopesEnum PostUsers =
        new(Values.PostUsers);

    public static readonly IdentityProvidersConfigProvisioningConfigurationScimTokensScopesEnum PatchUsers =
        new(Values.PatchUsers);

    public static readonly IdentityProvidersConfigProvisioningConfigurationScimTokensScopesEnum DeleteUsers =
        new(Values.DeleteUsers);

    public static readonly IdentityProvidersConfigProvisioningConfigurationScimTokensScopesEnum PutUsers =
        new(Values.PutUsers);

    public IdentityProvidersConfigProvisioningConfigurationScimTokensScopesEnum(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static IdentityProvidersConfigProvisioningConfigurationScimTokensScopesEnum FromCustom(
        string value
    )
    {
        return new IdentityProvidersConfigProvisioningConfigurationScimTokensScopesEnum(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(
        IdentityProvidersConfigProvisioningConfigurationScimTokensScopesEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        IdentityProvidersConfigProvisioningConfigurationScimTokensScopesEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        IdentityProvidersConfigProvisioningConfigurationScimTokensScopesEnum value
    ) => value.Value;

    public static explicit operator IdentityProvidersConfigProvisioningConfigurationScimTokensScopesEnum(
        string value
    ) => new(value);

    internal class IdentityProvidersConfigProvisioningConfigurationScimTokensScopesEnumSerializer
        : JsonConverter<IdentityProvidersConfigProvisioningConfigurationScimTokensScopesEnum>
    {
        public override IdentityProvidersConfigProvisioningConfigurationScimTokensScopesEnum Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new IdentityProvidersConfigProvisioningConfigurationScimTokensScopesEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            IdentityProvidersConfigProvisioningConfigurationScimTokensScopesEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override IdentityProvidersConfigProvisioningConfigurationScimTokensScopesEnum ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new IdentityProvidersConfigProvisioningConfigurationScimTokensScopesEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            IdentityProvidersConfigProvisioningConfigurationScimTokensScopesEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string GetUsers = "get:users";

        public const string PostUsers = "post:users";

        public const string PatchUsers = "patch:users";

        public const string DeleteUsers = "delete:users";

        public const string PutUsers = "put:users";
    }
}
