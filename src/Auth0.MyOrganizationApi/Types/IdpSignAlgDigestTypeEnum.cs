using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.MyOrganizationApi.Core;

namespace Auth0.MyOrganizationApi;

[JsonConverter(typeof(IdpSignAlgDigestTypeEnum.IdpSignAlgDigestTypeEnumSerializer))]
[Serializable]
public readonly record struct IdpSignAlgDigestTypeEnum : IStringEnum
{
    public static readonly IdpSignAlgDigestTypeEnum Sha256 = new(Values.Sha256);

    public static readonly IdpSignAlgDigestTypeEnum Sha1 = new(Values.Sha1);

    public IdpSignAlgDigestTypeEnum(string value)
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
    public static IdpSignAlgDigestTypeEnum FromCustom(string value)
    {
        return new IdpSignAlgDigestTypeEnum(value);
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

    public static bool operator ==(IdpSignAlgDigestTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(IdpSignAlgDigestTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(IdpSignAlgDigestTypeEnum value) => value.Value;

    public static explicit operator IdpSignAlgDigestTypeEnum(string value) => new(value);

    internal class IdpSignAlgDigestTypeEnumSerializer : JsonConverter<IdpSignAlgDigestTypeEnum>
    {
        public override IdpSignAlgDigestTypeEnum Read(
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
            return new IdpSignAlgDigestTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            IdpSignAlgDigestTypeEnum value,
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
        public const string Sha256 = "sha256";

        public const string Sha1 = "sha1";
    }
}
