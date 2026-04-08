using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.MyOrganizationApi.Core;

namespace Auth0.MyOrganizationApi;

[JsonConverter(typeof(IdpSignAlgTypeEnum.IdpSignAlgTypeEnumSerializer))]
[Serializable]
public readonly record struct IdpSignAlgTypeEnum : IStringEnum
{
    public static readonly IdpSignAlgTypeEnum RsaSha256 = new(Values.RsaSha256);

    public static readonly IdpSignAlgTypeEnum RsaSha1 = new(Values.RsaSha1);

    public IdpSignAlgTypeEnum(string value)
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
    public static IdpSignAlgTypeEnum FromCustom(string value)
    {
        return new IdpSignAlgTypeEnum(value);
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

    public static bool operator ==(IdpSignAlgTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(IdpSignAlgTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(IdpSignAlgTypeEnum value) => value.Value;

    public static explicit operator IdpSignAlgTypeEnum(string value) => new(value);

    internal class IdpSignAlgTypeEnumSerializer : JsonConverter<IdpSignAlgTypeEnum>
    {
        public override IdpSignAlgTypeEnum Read(
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
            return new IdpSignAlgTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            IdpSignAlgTypeEnum value,
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
        public const string RsaSha256 = "rsa-sha256";

        public const string RsaSha1 = "rsa-sha1";
    }
}
