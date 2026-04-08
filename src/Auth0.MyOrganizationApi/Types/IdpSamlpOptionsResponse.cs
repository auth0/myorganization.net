// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.MyOrganizationApi.Core;

namespace Auth0.MyOrganizationApi;

[JsonConverter(typeof(IdpSamlpOptionsResponse.JsonConverter))]
[Serializable]
public class IdpSamlpOptionsResponse
{
    private IdpSamlpOptionsResponse(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Type discriminator
    /// </summary>
    [JsonIgnore]
    public string Type { get; internal set; }

    /// <summary>
    /// Union value
    /// </summary>
    [JsonIgnore]
    public object? Value { get; internal set; }

    /// <summary>
    /// Factory method to create a union from a Auth0.MyOrganizationApi.Automatic value.
    /// </summary>
    public static IdpSamlpOptionsResponse FromAutomatic(Auth0.MyOrganizationApi.Automatic value) =>
        new("automatic", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.MyOrganizationApi.Manual value.
    /// </summary>
    public static IdpSamlpOptionsResponse FromManual(Auth0.MyOrganizationApi.Manual value) =>
        new("manual", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "automatic"
    /// </summary>
    public bool IsAutomatic() => Type == "automatic";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "manual"
    /// </summary>
    public bool IsManual() => Type == "manual";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.MyOrganizationApi.Automatic"/> if <see cref="Type"/> is 'automatic', otherwise throws an exception.
    /// </summary>
    /// <exception cref="MyOrganizationException">Thrown when <see cref="Type"/> is not 'automatic'.</exception>
    public Auth0.MyOrganizationApi.Automatic AsAutomatic() =>
        IsAutomatic()
            ? (Auth0.MyOrganizationApi.Automatic)Value!
            : throw new MyOrganizationException("Union type is not 'automatic'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.MyOrganizationApi.Manual"/> if <see cref="Type"/> is 'manual', otherwise throws an exception.
    /// </summary>
    /// <exception cref="MyOrganizationException">Thrown when <see cref="Type"/> is not 'manual'.</exception>
    public Auth0.MyOrganizationApi.Manual AsManual() =>
        IsManual()
            ? (Auth0.MyOrganizationApi.Manual)Value!
            : throw new MyOrganizationException("Union type is not 'manual'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.MyOrganizationApi.Automatic"/> and returns true if successful.
    /// </summary>
    public bool TryGetAutomatic(out Auth0.MyOrganizationApi.Automatic? value)
    {
        if (Type == "automatic")
        {
            value = (Auth0.MyOrganizationApi.Automatic)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.MyOrganizationApi.Manual"/> and returns true if successful.
    /// </summary>
    public bool TryGetManual(out Auth0.MyOrganizationApi.Manual? value)
    {
        if (Type == "manual")
        {
            value = (Auth0.MyOrganizationApi.Manual)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Auth0.MyOrganizationApi.Automatic, T> onAutomatic,
        Func<Auth0.MyOrganizationApi.Manual, T> onManual
    )
    {
        return Type switch
        {
            "automatic" => onAutomatic(AsAutomatic()),
            "manual" => onManual(AsManual()),
            _ => throw new MyOrganizationException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        Action<Auth0.MyOrganizationApi.Automatic> onAutomatic,
        Action<Auth0.MyOrganizationApi.Manual> onManual
    )
    {
        switch (Type)
        {
            case "automatic":
                onAutomatic(AsAutomatic());
                break;
            case "manual":
                onManual(AsManual());
                break;
            default:
                throw new MyOrganizationException($"Unknown union type: {Type}");
        }
    }

    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = Type.GetHashCode();
            if (Value != null)
            {
                hashCode = (hashCode * 397) ^ Value.GetHashCode();
            }
            return hashCode;
        }
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        if (obj is not IdpSamlpOptionsResponse other)
            return false;

        // Compare type discriminators
        if (Type != other.Type)
            return false;

        // Compare values using EqualityComparer for deep comparison
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator IdpSamlpOptionsResponse(
        Auth0.MyOrganizationApi.Automatic value
    ) => new("automatic", value);

    public static implicit operator IdpSamlpOptionsResponse(Auth0.MyOrganizationApi.Manual value) =>
        new("manual", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<IdpSamlpOptionsResponse>
    {
        public override IdpSamlpOptionsResponse? Read(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            if (reader.TokenType == JsonTokenType.StartObject)
            {
                var document = JsonDocument.ParseValue(ref reader);

                var types = new (string Key, System.Type Type)[]
                {
                    ("automatic", typeof(Auth0.MyOrganizationApi.Automatic)),
                    ("manual", typeof(Auth0.MyOrganizationApi.Manual)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            IdpSamlpOptionsResponse result = new(key, value);
                            return result;
                        }
                    }
                    catch (JsonException)
                    {
                        // Try next type;
                    }
                }
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into IdpSamlpOptionsResponse"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            IdpSamlpOptionsResponse value,
            JsonSerializerOptions options
        )
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            value.Visit(
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override IdpSamlpOptionsResponse ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            IdpSamlpOptionsResponse result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            IdpSamlpOptionsResponse value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
