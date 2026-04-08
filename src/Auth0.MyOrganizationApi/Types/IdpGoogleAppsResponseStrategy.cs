using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.MyOrganizationApi.Core;

namespace Auth0.MyOrganizationApi;

[JsonConverter(typeof(IdpGoogleAppsResponseStrategy.IdpGoogleAppsResponseStrategySerializer))]
[Serializable]
public readonly record struct IdpGoogleAppsResponseStrategy : IStringEnum
{
    public static readonly IdpGoogleAppsResponseStrategy GoogleApps = new(Values.GoogleApps);

    public IdpGoogleAppsResponseStrategy(string value)
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
    public static IdpGoogleAppsResponseStrategy FromCustom(string value)
    {
        return new IdpGoogleAppsResponseStrategy(value);
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

    public static bool operator ==(IdpGoogleAppsResponseStrategy value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(IdpGoogleAppsResponseStrategy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(IdpGoogleAppsResponseStrategy value) => value.Value;

    public static explicit operator IdpGoogleAppsResponseStrategy(string value) => new(value);

    internal class IdpGoogleAppsResponseStrategySerializer
        : JsonConverter<IdpGoogleAppsResponseStrategy>
    {
        public override IdpGoogleAppsResponseStrategy Read(
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
            return new IdpGoogleAppsResponseStrategy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            IdpGoogleAppsResponseStrategy value,
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
        public const string GoogleApps = "google-apps";
    }
}
