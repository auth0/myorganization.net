using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.MyOrganizationApi.Core;

namespace Auth0.MyOrganizationApi;

[JsonConverter(
    typeof(IdentityProvidersConfigProvisioningMethodsEnum.IdentityProvidersConfigProvisioningMethodsEnumSerializer)
)]
[Serializable]
public readonly record struct IdentityProvidersConfigProvisioningMethodsEnum : IStringEnum
{
    public static readonly IdentityProvidersConfigProvisioningMethodsEnum Scim = new(Values.Scim);

    public static readonly IdentityProvidersConfigProvisioningMethodsEnum GoogleSync = new(
        Values.GoogleSync
    );

    public IdentityProvidersConfigProvisioningMethodsEnum(string value)
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
    public static IdentityProvidersConfigProvisioningMethodsEnum FromCustom(string value)
    {
        return new IdentityProvidersConfigProvisioningMethodsEnum(value);
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
        IdentityProvidersConfigProvisioningMethodsEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        IdentityProvidersConfigProvisioningMethodsEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(IdentityProvidersConfigProvisioningMethodsEnum value) =>
        value.Value;

    public static explicit operator IdentityProvidersConfigProvisioningMethodsEnum(string value) =>
        new(value);

    internal class IdentityProvidersConfigProvisioningMethodsEnumSerializer
        : JsonConverter<IdentityProvidersConfigProvisioningMethodsEnum>
    {
        public override IdentityProvidersConfigProvisioningMethodsEnum Read(
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
            return new IdentityProvidersConfigProvisioningMethodsEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            IdentityProvidersConfigProvisioningMethodsEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Scim = "scim";

        public const string GoogleSync = "google-sync";
    }
}
