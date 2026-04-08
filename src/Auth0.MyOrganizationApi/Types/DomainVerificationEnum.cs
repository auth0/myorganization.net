using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.MyOrganizationApi.Core;

namespace Auth0.MyOrganizationApi;

[JsonConverter(typeof(DomainVerificationEnum.DomainVerificationEnumSerializer))]
[Serializable]
public readonly record struct DomainVerificationEnum : IStringEnum
{
    public static readonly DomainVerificationEnum None = new(Values.None);

    public static readonly DomainVerificationEnum Optional = new(Values.Optional);

    public static readonly DomainVerificationEnum Required = new(Values.Required);

    public DomainVerificationEnum(string value)
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
    public static DomainVerificationEnum FromCustom(string value)
    {
        return new DomainVerificationEnum(value);
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

    public static bool operator ==(DomainVerificationEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DomainVerificationEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DomainVerificationEnum value) => value.Value;

    public static explicit operator DomainVerificationEnum(string value) => new(value);

    internal class DomainVerificationEnumSerializer : JsonConverter<DomainVerificationEnum>
    {
        public override DomainVerificationEnum Read(
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
            return new DomainVerificationEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DomainVerificationEnum value,
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
        public const string None = "none";

        public const string Optional = "optional";

        public const string Required = "required";
    }
}
