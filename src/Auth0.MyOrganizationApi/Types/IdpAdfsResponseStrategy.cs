using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.MyOrganizationApi.Core;

namespace Auth0.MyOrganizationApi;

[JsonConverter(typeof(IdpAdfsResponseStrategy.IdpAdfsResponseStrategySerializer))]
[Serializable]
public readonly record struct IdpAdfsResponseStrategy : IStringEnum
{
    public static readonly IdpAdfsResponseStrategy Adfs = new(Values.Adfs);

    public IdpAdfsResponseStrategy(string value)
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
    public static IdpAdfsResponseStrategy FromCustom(string value)
    {
        return new IdpAdfsResponseStrategy(value);
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

    public static bool operator ==(IdpAdfsResponseStrategy value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(IdpAdfsResponseStrategy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(IdpAdfsResponseStrategy value) => value.Value;

    public static explicit operator IdpAdfsResponseStrategy(string value) => new(value);

    internal class IdpAdfsResponseStrategySerializer : JsonConverter<IdpAdfsResponseStrategy>
    {
        public override IdpAdfsResponseStrategy Read(
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
            return new IdpAdfsResponseStrategy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            IdpAdfsResponseStrategy value,
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
        public const string Adfs = "adfs";
    }
}
