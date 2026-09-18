// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

[JsonConverter(typeof(IdpSamlpOptionsRequest.JsonConverter))]
[Serializable]
public class IdpSamlpOptionsRequest
{
    private IdpSamlpOptionsRequest(string type, object? value)
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
    /// Factory method to create a union from a Auth0.MyOrganizationApi.IdpSamlpOptionsRequestMetadataUrl value.
    /// </summary>
    public static IdpSamlpOptionsRequest FromIdpSamlpOptionsRequestMetadataUrl(
        Auth0.MyOrganizationApi.IdpSamlpOptionsRequestMetadataUrl value
    ) => new("idpSamlpOptionsRequestMetadataUrl", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.MyOrganizationApi.IdpSamlpOptionsRequestSignInEndpoint value.
    /// </summary>
    public static IdpSamlpOptionsRequest FromIdpSamlpOptionsRequestSignInEndpoint(
        Auth0.MyOrganizationApi.IdpSamlpOptionsRequestSignInEndpoint value
    ) => new("idpSamlpOptionsRequestSignInEndpoint", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "idpSamlpOptionsRequestMetadataUrl"
    /// </summary>
    public bool IsIdpSamlpOptionsRequestMetadataUrl() =>
        Type == "idpSamlpOptionsRequestMetadataUrl";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "idpSamlpOptionsRequestSignInEndpoint"
    /// </summary>
    public bool IsIdpSamlpOptionsRequestSignInEndpoint() =>
        Type == "idpSamlpOptionsRequestSignInEndpoint";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.MyOrganizationApi.IdpSamlpOptionsRequestMetadataUrl"/> if <see cref="Type"/> is 'idpSamlpOptionsRequestMetadataUrl', otherwise throws an exception.
    /// </summary>
    /// <exception cref="MyOrganizationException">Thrown when <see cref="Type"/> is not 'idpSamlpOptionsRequestMetadataUrl'.</exception>
    public Auth0.MyOrganizationApi.IdpSamlpOptionsRequestMetadataUrl AsIdpSamlpOptionsRequestMetadataUrl() =>
        IsIdpSamlpOptionsRequestMetadataUrl()
            ? (Auth0.MyOrganizationApi.IdpSamlpOptionsRequestMetadataUrl)Value!
            : throw new MyOrganizationException(
                "Union type is not 'idpSamlpOptionsRequestMetadataUrl'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.MyOrganizationApi.IdpSamlpOptionsRequestSignInEndpoint"/> if <see cref="Type"/> is 'idpSamlpOptionsRequestSignInEndpoint', otherwise throws an exception.
    /// </summary>
    /// <exception cref="MyOrganizationException">Thrown when <see cref="Type"/> is not 'idpSamlpOptionsRequestSignInEndpoint'.</exception>
    public Auth0.MyOrganizationApi.IdpSamlpOptionsRequestSignInEndpoint AsIdpSamlpOptionsRequestSignInEndpoint() =>
        IsIdpSamlpOptionsRequestSignInEndpoint()
            ? (Auth0.MyOrganizationApi.IdpSamlpOptionsRequestSignInEndpoint)Value!
            : throw new MyOrganizationException(
                "Union type is not 'idpSamlpOptionsRequestSignInEndpoint'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.MyOrganizationApi.IdpSamlpOptionsRequestMetadataUrl"/> and returns true if successful.
    /// </summary>
    public bool TryGetIdpSamlpOptionsRequestMetadataUrl(
        out Auth0.MyOrganizationApi.IdpSamlpOptionsRequestMetadataUrl? value
    )
    {
        if (Type == "idpSamlpOptionsRequestMetadataUrl")
        {
            value = (Auth0.MyOrganizationApi.IdpSamlpOptionsRequestMetadataUrl)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.MyOrganizationApi.IdpSamlpOptionsRequestSignInEndpoint"/> and returns true if successful.
    /// </summary>
    public bool TryGetIdpSamlpOptionsRequestSignInEndpoint(
        out Auth0.MyOrganizationApi.IdpSamlpOptionsRequestSignInEndpoint? value
    )
    {
        if (Type == "idpSamlpOptionsRequestSignInEndpoint")
        {
            value = (Auth0.MyOrganizationApi.IdpSamlpOptionsRequestSignInEndpoint)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.MyOrganizationApi.IdpSamlpOptionsRequestMetadataUrl,
            T
        > onIdpSamlpOptionsRequestMetadataUrl,
        Func<
            Auth0.MyOrganizationApi.IdpSamlpOptionsRequestSignInEndpoint,
            T
        > onIdpSamlpOptionsRequestSignInEndpoint
    )
    {
        return Type switch
        {
            "idpSamlpOptionsRequestMetadataUrl" => onIdpSamlpOptionsRequestMetadataUrl(
                AsIdpSamlpOptionsRequestMetadataUrl()
            ),
            "idpSamlpOptionsRequestSignInEndpoint" => onIdpSamlpOptionsRequestSignInEndpoint(
                AsIdpSamlpOptionsRequestSignInEndpoint()
            ),
            _ => throw new MyOrganizationException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        Action<Auth0.MyOrganizationApi.IdpSamlpOptionsRequestMetadataUrl> onIdpSamlpOptionsRequestMetadataUrl,
        Action<Auth0.MyOrganizationApi.IdpSamlpOptionsRequestSignInEndpoint> onIdpSamlpOptionsRequestSignInEndpoint
    )
    {
        switch (Type)
        {
            case "idpSamlpOptionsRequestMetadataUrl":
                onIdpSamlpOptionsRequestMetadataUrl(AsIdpSamlpOptionsRequestMetadataUrl());
                break;
            case "idpSamlpOptionsRequestSignInEndpoint":
                onIdpSamlpOptionsRequestSignInEndpoint(AsIdpSamlpOptionsRequestSignInEndpoint());
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
        if (obj is not IdpSamlpOptionsRequest other)
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

    public static implicit operator IdpSamlpOptionsRequest(
        Auth0.MyOrganizationApi.IdpSamlpOptionsRequestMetadataUrl value
    ) => new("idpSamlpOptionsRequestMetadataUrl", value);

    public static implicit operator IdpSamlpOptionsRequest(
        Auth0.MyOrganizationApi.IdpSamlpOptionsRequestSignInEndpoint value
    ) => new("idpSamlpOptionsRequestSignInEndpoint", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<IdpSamlpOptionsRequest>
    {
        public override IdpSamlpOptionsRequest? Read(
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
                    (
                        "idpSamlpOptionsRequestMetadataUrl",
                        typeof(Auth0.MyOrganizationApi.IdpSamlpOptionsRequestMetadataUrl)
                    ),
                    (
                        "idpSamlpOptionsRequestSignInEndpoint",
                        typeof(Auth0.MyOrganizationApi.IdpSamlpOptionsRequestSignInEndpoint)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            IdpSamlpOptionsRequest result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into IdpSamlpOptionsRequest"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            IdpSamlpOptionsRequest value,
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

        public override IdpSamlpOptionsRequest ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            IdpSamlpOptionsRequest result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            IdpSamlpOptionsRequest value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
