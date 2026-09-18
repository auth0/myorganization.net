using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

[JsonConverter(typeof(OrgThirdPartyClientAccessEnum.OrgThirdPartyClientAccessEnumSerializer))]
[Serializable]
public readonly record struct OrgThirdPartyClientAccessEnum : IStringEnum
{
    public static readonly OrgThirdPartyClientAccessEnum Allow = new(Values.Allow);

    public static readonly OrgThirdPartyClientAccessEnum Block = new(Values.Block);

    public OrgThirdPartyClientAccessEnum(string value)
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
    public static OrgThirdPartyClientAccessEnum FromCustom(string value)
    {
        return new OrgThirdPartyClientAccessEnum(value);
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

    public static bool operator ==(OrgThirdPartyClientAccessEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OrgThirdPartyClientAccessEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OrgThirdPartyClientAccessEnum value) => value.Value;

    public static explicit operator OrgThirdPartyClientAccessEnum(string value) => new(value);

    internal class OrgThirdPartyClientAccessEnumSerializer
        : JsonConverter<OrgThirdPartyClientAccessEnum>
    {
        public override OrgThirdPartyClientAccessEnum Read(
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
            return new OrgThirdPartyClientAccessEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OrgThirdPartyClientAccessEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override OrgThirdPartyClientAccessEnum ReadAsPropertyName(
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
            return new OrgThirdPartyClientAccessEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OrgThirdPartyClientAccessEnum value,
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
        public const string Allow = "allow";

        public const string Block = "block";
    }
}
