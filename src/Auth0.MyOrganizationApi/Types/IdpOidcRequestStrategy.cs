using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

[JsonConverter(typeof(IdpOidcRequestStrategy.IdpOidcRequestStrategySerializer))]
[Serializable]
public readonly record struct IdpOidcRequestStrategy : IStringEnum
{
    public static readonly IdpOidcRequestStrategy Oidc = new(Values.Oidc);

    public IdpOidcRequestStrategy(string value)
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
    public static IdpOidcRequestStrategy FromCustom(string value)
    {
        return new IdpOidcRequestStrategy(value);
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

    public static bool operator ==(IdpOidcRequestStrategy value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(IdpOidcRequestStrategy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(IdpOidcRequestStrategy value) => value.Value;

    public static explicit operator IdpOidcRequestStrategy(string value) => new(value);

    internal class IdpOidcRequestStrategySerializer : JsonConverter<IdpOidcRequestStrategy>
    {
        public override IdpOidcRequestStrategy Read(
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
            return new IdpOidcRequestStrategy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            IdpOidcRequestStrategy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override IdpOidcRequestStrategy ReadAsPropertyName(
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
            return new IdpOidcRequestStrategy(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            IdpOidcRequestStrategy value,
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
        public const string Oidc = "oidc";
    }
}
