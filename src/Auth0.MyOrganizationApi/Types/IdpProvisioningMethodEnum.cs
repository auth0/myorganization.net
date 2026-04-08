using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.MyOrganizationApi.Core;

namespace Auth0.MyOrganizationApi;

[JsonConverter(typeof(IdpProvisioningMethodEnum.IdpProvisioningMethodEnumSerializer))]
[Serializable]
public readonly record struct IdpProvisioningMethodEnum : IStringEnum
{
    public static readonly IdpProvisioningMethodEnum GoogleSync = new(Values.GoogleSync);

    public static readonly IdpProvisioningMethodEnum None = new(Values.None);

    public static readonly IdpProvisioningMethodEnum Scim = new(Values.Scim);

    public IdpProvisioningMethodEnum(string value)
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
    public static IdpProvisioningMethodEnum FromCustom(string value)
    {
        return new IdpProvisioningMethodEnum(value);
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

    public static bool operator ==(IdpProvisioningMethodEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(IdpProvisioningMethodEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(IdpProvisioningMethodEnum value) => value.Value;

    public static explicit operator IdpProvisioningMethodEnum(string value) => new(value);

    internal class IdpProvisioningMethodEnumSerializer : JsonConverter<IdpProvisioningMethodEnum>
    {
        public override IdpProvisioningMethodEnum Read(
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
            return new IdpProvisioningMethodEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            IdpProvisioningMethodEnum value,
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
        public const string GoogleSync = "google-sync";

        public const string None = "none";

        public const string Scim = "scim";
    }
}
