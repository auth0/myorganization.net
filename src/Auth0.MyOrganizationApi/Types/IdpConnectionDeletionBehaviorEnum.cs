using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.MyOrganizationApi.Core;

namespace Auth0.MyOrganizationApi;

[JsonConverter(
    typeof(IdpConnectionDeletionBehaviorEnum.IdpConnectionDeletionBehaviorEnumSerializer)
)]
[Serializable]
public readonly record struct IdpConnectionDeletionBehaviorEnum : IStringEnum
{
    public static readonly IdpConnectionDeletionBehaviorEnum Allow = new(Values.Allow);

    public static readonly IdpConnectionDeletionBehaviorEnum AllowIfEmpty = new(
        Values.AllowIfEmpty
    );

    public IdpConnectionDeletionBehaviorEnum(string value)
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
    public static IdpConnectionDeletionBehaviorEnum FromCustom(string value)
    {
        return new IdpConnectionDeletionBehaviorEnum(value);
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

    public static bool operator ==(IdpConnectionDeletionBehaviorEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(IdpConnectionDeletionBehaviorEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(IdpConnectionDeletionBehaviorEnum value) => value.Value;

    public static explicit operator IdpConnectionDeletionBehaviorEnum(string value) => new(value);

    internal class IdpConnectionDeletionBehaviorEnumSerializer
        : JsonConverter<IdpConnectionDeletionBehaviorEnum>
    {
        public override IdpConnectionDeletionBehaviorEnum Read(
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
            return new IdpConnectionDeletionBehaviorEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            IdpConnectionDeletionBehaviorEnum value,
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
        public const string Allow = "allow";

        public const string AllowIfEmpty = "allow_if_empty";
    }
}
