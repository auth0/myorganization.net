using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

[JsonConverter(typeof(IdpWaadRequestStrategy.IdpWaadRequestStrategySerializer))]
[Serializable]
public readonly record struct IdpWaadRequestStrategy : IStringEnum
{
    public static readonly IdpWaadRequestStrategy Waad = new(Values.Waad);

    public IdpWaadRequestStrategy(string value)
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
    public static IdpWaadRequestStrategy FromCustom(string value)
    {
        return new IdpWaadRequestStrategy(value);
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

    public static bool operator ==(IdpWaadRequestStrategy value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(IdpWaadRequestStrategy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(IdpWaadRequestStrategy value) => value.Value;

    public static explicit operator IdpWaadRequestStrategy(string value) => new(value);

    internal class IdpWaadRequestStrategySerializer : JsonConverter<IdpWaadRequestStrategy>
    {
        public override IdpWaadRequestStrategy Read(
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
            return new IdpWaadRequestStrategy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            IdpWaadRequestStrategy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override IdpWaadRequestStrategy ReadAsPropertyName(
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
            return new IdpWaadRequestStrategy(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            IdpWaadRequestStrategy value,
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
        public const string Waad = "waad";
    }
}
