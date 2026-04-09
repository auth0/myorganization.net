using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

[JsonConverter(typeof(IdpOidcOptionsTypeEnum.IdpOidcOptionsTypeEnumSerializer))]
[Serializable]
public readonly record struct IdpOidcOptionsTypeEnum : IStringEnum
{
    public static readonly IdpOidcOptionsTypeEnum FrontChannel = new(Values.FrontChannel);

    public static readonly IdpOidcOptionsTypeEnum BackChannel = new(Values.BackChannel);

    public IdpOidcOptionsTypeEnum(string value)
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
    public static IdpOidcOptionsTypeEnum FromCustom(string value)
    {
        return new IdpOidcOptionsTypeEnum(value);
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

    public static bool operator ==(IdpOidcOptionsTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(IdpOidcOptionsTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(IdpOidcOptionsTypeEnum value) => value.Value;

    public static explicit operator IdpOidcOptionsTypeEnum(string value) => new(value);

    internal class IdpOidcOptionsTypeEnumSerializer : JsonConverter<IdpOidcOptionsTypeEnum>
    {
        public override IdpOidcOptionsTypeEnum Read(
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
            return new IdpOidcOptionsTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            IdpOidcOptionsTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override IdpOidcOptionsTypeEnum ReadAsPropertyName(
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
            return new IdpOidcOptionsTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            IdpOidcOptionsTypeEnum value,
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
        public const string FrontChannel = "front_channel";

        public const string BackChannel = "back_channel";
    }
}
