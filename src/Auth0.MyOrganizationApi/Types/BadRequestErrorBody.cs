// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

[JsonConverter(typeof(BadRequestErrorBody.JsonConverter))]
[Serializable]
public class BadRequestErrorBody
{
    private BadRequestErrorBody(string type, object? value)
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
    /// Factory method to create a union from a Auth0.MyOrganizationApi.ErrorResponseContent value.
    /// </summary>
    public static BadRequestErrorBody FromErrorResponseContent(
        Auth0.MyOrganizationApi.ErrorResponseContent value
    ) => new("errorResponseContent", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.MyOrganizationApi.ValidationErrorResponseContent value.
    /// </summary>
    public static BadRequestErrorBody FromValidationErrorResponseContent(
        Auth0.MyOrganizationApi.ValidationErrorResponseContent value
    ) => new("validationErrorResponseContent", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "errorResponseContent"
    /// </summary>
    public bool IsErrorResponseContent() => Type == "errorResponseContent";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "validationErrorResponseContent"
    /// </summary>
    public bool IsValidationErrorResponseContent() => Type == "validationErrorResponseContent";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.MyOrganizationApi.ErrorResponseContent"/> if <see cref="Type"/> is 'errorResponseContent', otherwise throws an exception.
    /// </summary>
    /// <exception cref="MyOrganizationException">Thrown when <see cref="Type"/> is not 'errorResponseContent'.</exception>
    public Auth0.MyOrganizationApi.ErrorResponseContent AsErrorResponseContent() =>
        IsErrorResponseContent()
            ? (Auth0.MyOrganizationApi.ErrorResponseContent)Value!
            : throw new MyOrganizationException("Union type is not 'errorResponseContent'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.MyOrganizationApi.ValidationErrorResponseContent"/> if <see cref="Type"/> is 'validationErrorResponseContent', otherwise throws an exception.
    /// </summary>
    /// <exception cref="MyOrganizationException">Thrown when <see cref="Type"/> is not 'validationErrorResponseContent'.</exception>
    public Auth0.MyOrganizationApi.ValidationErrorResponseContent AsValidationErrorResponseContent() =>
        IsValidationErrorResponseContent()
            ? (Auth0.MyOrganizationApi.ValidationErrorResponseContent)Value!
            : throw new MyOrganizationException(
                "Union type is not 'validationErrorResponseContent'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.MyOrganizationApi.ErrorResponseContent"/> and returns true if successful.
    /// </summary>
    public bool TryGetErrorResponseContent(out Auth0.MyOrganizationApi.ErrorResponseContent? value)
    {
        if (Type == "errorResponseContent")
        {
            value = (Auth0.MyOrganizationApi.ErrorResponseContent)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.MyOrganizationApi.ValidationErrorResponseContent"/> and returns true if successful.
    /// </summary>
    public bool TryGetValidationErrorResponseContent(
        out Auth0.MyOrganizationApi.ValidationErrorResponseContent? value
    )
    {
        if (Type == "validationErrorResponseContent")
        {
            value = (Auth0.MyOrganizationApi.ValidationErrorResponseContent)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Auth0.MyOrganizationApi.ErrorResponseContent, T> onErrorResponseContent,
        Func<
            Auth0.MyOrganizationApi.ValidationErrorResponseContent,
            T
        > onValidationErrorResponseContent
    )
    {
        return Type switch
        {
            "errorResponseContent" => onErrorResponseContent(AsErrorResponseContent()),
            "validationErrorResponseContent" => onValidationErrorResponseContent(
                AsValidationErrorResponseContent()
            ),
            _ => throw new MyOrganizationException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        Action<Auth0.MyOrganizationApi.ErrorResponseContent> onErrorResponseContent,
        Action<Auth0.MyOrganizationApi.ValidationErrorResponseContent> onValidationErrorResponseContent
    )
    {
        switch (Type)
        {
            case "errorResponseContent":
                onErrorResponseContent(AsErrorResponseContent());
                break;
            case "validationErrorResponseContent":
                onValidationErrorResponseContent(AsValidationErrorResponseContent());
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
        if (obj is not BadRequestErrorBody other)
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

    public static implicit operator BadRequestErrorBody(
        Auth0.MyOrganizationApi.ErrorResponseContent value
    ) => new("errorResponseContent", value);

    public static implicit operator BadRequestErrorBody(
        Auth0.MyOrganizationApi.ValidationErrorResponseContent value
    ) => new("validationErrorResponseContent", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<BadRequestErrorBody>
    {
        public override BadRequestErrorBody? Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
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
                    ("errorResponseContent", typeof(Auth0.MyOrganizationApi.ErrorResponseContent)),
                    (
                        "validationErrorResponseContent",
                        typeof(Auth0.MyOrganizationApi.ValidationErrorResponseContent)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            BadRequestErrorBody result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into BadRequestErrorBody"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            BadRequestErrorBody value,
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

        public override BadRequestErrorBody ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            BadRequestErrorBody result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BadRequestErrorBody value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
