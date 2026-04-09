using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

[JsonConverter(typeof(IdpPingFederateResponseStrategy.IdpPingFederateResponseStrategySerializer))]
[Serializable]
public readonly record struct IdpPingFederateResponseStrategy : IStringEnum
{
    public static readonly IdpPingFederateResponseStrategy Pingfederate = new(Values.Pingfederate);

    public IdpPingFederateResponseStrategy(string value)
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
    public static IdpPingFederateResponseStrategy FromCustom(string value)
    {
        return new IdpPingFederateResponseStrategy(value);
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

    public static bool operator ==(IdpPingFederateResponseStrategy value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(IdpPingFederateResponseStrategy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(IdpPingFederateResponseStrategy value) => value.Value;

    public static explicit operator IdpPingFederateResponseStrategy(string value) => new(value);

    internal class IdpPingFederateResponseStrategySerializer
        : JsonConverter<IdpPingFederateResponseStrategy>
    {
        public override IdpPingFederateResponseStrategy Read(
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
            return new IdpPingFederateResponseStrategy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            IdpPingFederateResponseStrategy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override IdpPingFederateResponseStrategy ReadAsPropertyName(
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
            return new IdpPingFederateResponseStrategy(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            IdpPingFederateResponseStrategy value,
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
        public const string Pingfederate = "pingfederate";
    }
}
