using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

[JsonConverter(typeof(IdpOktaResponseStrategy.IdpOktaResponseStrategySerializer))]
[Serializable]
public readonly record struct IdpOktaResponseStrategy : IStringEnum
{
    public static readonly IdpOktaResponseStrategy Okta = new(Values.Okta);

    public IdpOktaResponseStrategy(string value)
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
    public static IdpOktaResponseStrategy FromCustom(string value)
    {
        return new IdpOktaResponseStrategy(value);
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

    public static bool operator ==(IdpOktaResponseStrategy value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(IdpOktaResponseStrategy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(IdpOktaResponseStrategy value) => value.Value;

    public static explicit operator IdpOktaResponseStrategy(string value) => new(value);

    internal class IdpOktaResponseStrategySerializer : JsonConverter<IdpOktaResponseStrategy>
    {
        public override IdpOktaResponseStrategy Read(
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
            return new IdpOktaResponseStrategy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            IdpOktaResponseStrategy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override IdpOktaResponseStrategy ReadAsPropertyName(
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
            return new IdpOktaResponseStrategy(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            IdpOktaResponseStrategy value,
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
        public const string Okta = "okta";
    }
}
