using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

[JsonConverter(
    typeof(IdentityProvidersConfigEnabledFeaturesEnum.IdentityProvidersConfigEnabledFeaturesEnumSerializer)
)]
[Serializable]
public readonly record struct IdentityProvidersConfigEnabledFeaturesEnum : IStringEnum
{
    public static readonly IdentityProvidersConfigEnabledFeaturesEnum Provisioning = new(
        Values.Provisioning
    );

    public static readonly IdentityProvidersConfigEnabledFeaturesEnum UniversalLogout = new(
        Values.UniversalLogout
    );

    public IdentityProvidersConfigEnabledFeaturesEnum(string value)
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
    public static IdentityProvidersConfigEnabledFeaturesEnum FromCustom(string value)
    {
        return new IdentityProvidersConfigEnabledFeaturesEnum(value);
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

    public static bool operator ==(
        IdentityProvidersConfigEnabledFeaturesEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        IdentityProvidersConfigEnabledFeaturesEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(IdentityProvidersConfigEnabledFeaturesEnum value) =>
        value.Value;

    public static explicit operator IdentityProvidersConfigEnabledFeaturesEnum(string value) =>
        new(value);

    internal class IdentityProvidersConfigEnabledFeaturesEnumSerializer
        : JsonConverter<IdentityProvidersConfigEnabledFeaturesEnum>
    {
        public override IdentityProvidersConfigEnabledFeaturesEnum Read(
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
            return new IdentityProvidersConfigEnabledFeaturesEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            IdentityProvidersConfigEnabledFeaturesEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override IdentityProvidersConfigEnabledFeaturesEnum ReadAsPropertyName(
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
            return new IdentityProvidersConfigEnabledFeaturesEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            IdentityProvidersConfigEnabledFeaturesEnum value,
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
        public const string Provisioning = "provisioning";

        public const string UniversalLogout = "universal_logout";
    }
}
