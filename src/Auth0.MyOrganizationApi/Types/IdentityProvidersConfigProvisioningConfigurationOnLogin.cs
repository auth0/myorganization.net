using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

[JsonConverter(
    typeof(IdentityProvidersConfigProvisioningConfigurationOnLogin.IdentityProvidersConfigProvisioningConfigurationOnLoginSerializer)
)]
[Serializable]
public readonly record struct IdentityProvidersConfigProvisioningConfigurationOnLogin : IStringEnum
{
    public static readonly IdentityProvidersConfigProvisioningConfigurationOnLogin NeverOnLogin =
        new(Values.NeverOnLogin);

    public static readonly IdentityProvidersConfigProvisioningConfigurationOnLogin OnFirstLogin =
        new(Values.OnFirstLogin);

    public static readonly IdentityProvidersConfigProvisioningConfigurationOnLogin OnEachLogin =
        new(Values.OnEachLogin);

    public IdentityProvidersConfigProvisioningConfigurationOnLogin(string value)
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
    public static IdentityProvidersConfigProvisioningConfigurationOnLogin FromCustom(string value)
    {
        return new IdentityProvidersConfigProvisioningConfigurationOnLogin(value);
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
        IdentityProvidersConfigProvisioningConfigurationOnLogin value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        IdentityProvidersConfigProvisioningConfigurationOnLogin value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        IdentityProvidersConfigProvisioningConfigurationOnLogin value
    ) => value.Value;

    public static explicit operator IdentityProvidersConfigProvisioningConfigurationOnLogin(
        string value
    ) => new(value);

    internal class IdentityProvidersConfigProvisioningConfigurationOnLoginSerializer
        : JsonConverter<IdentityProvidersConfigProvisioningConfigurationOnLogin>
    {
        public override IdentityProvidersConfigProvisioningConfigurationOnLogin Read(
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
            return new IdentityProvidersConfigProvisioningConfigurationOnLogin(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            IdentityProvidersConfigProvisioningConfigurationOnLogin value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override IdentityProvidersConfigProvisioningConfigurationOnLogin ReadAsPropertyName(
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
            return new IdentityProvidersConfigProvisioningConfigurationOnLogin(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            IdentityProvidersConfigProvisioningConfigurationOnLogin value,
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
        public const string NeverOnLogin = "never_on_login";

        public const string OnFirstLogin = "on_first_login";

        public const string OnEachLogin = "on_each_login";
    }
}
