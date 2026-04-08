using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.MyOrganizationApi.Core;

namespace Auth0.MyOrganizationApi;

[JsonConverter(typeof(IdpOidcResponseStrategy.IdpOidcResponseStrategySerializer))]
[Serializable]
public readonly record struct IdpOidcResponseStrategy : IStringEnum
{
    public static readonly IdpOidcResponseStrategy Oidc = new(Values.Oidc);

    public IdpOidcResponseStrategy(string value)
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
    public static IdpOidcResponseStrategy FromCustom(string value)
    {
        return new IdpOidcResponseStrategy(value);
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

    public static bool operator ==(IdpOidcResponseStrategy value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(IdpOidcResponseStrategy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(IdpOidcResponseStrategy value) => value.Value;

    public static explicit operator IdpOidcResponseStrategy(string value) => new(value);

    internal class IdpOidcResponseStrategySerializer : JsonConverter<IdpOidcResponseStrategy>
    {
        public override IdpOidcResponseStrategy Read(
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
            return new IdpOidcResponseStrategy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            IdpOidcResponseStrategy value,
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
        public const string Oidc = "oidc";
    }
}
