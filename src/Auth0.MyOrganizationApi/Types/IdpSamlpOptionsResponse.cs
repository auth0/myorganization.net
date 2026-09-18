// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

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
    /// Factory method to create a union from a Auth0.MyOrganizationApi.IdpSamlpOptionsResponseMetadataUrl value.
    /// </summary>
    public static IdpSamlpOptionsResponse FromIdpSamlpOptionsResponseMetadataUrl(
        Auth0.MyOrganizationApi.IdpSamlpOptionsResponseMetadataUrl value
    ) => new("idpSamlpOptionsResponseMetadataUrl", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.MyOrganizationApi.IdpSamlpOptionsResponseSignInEndpoint value.
    /// </summary>
    public static IdpSamlpOptionsResponse FromIdpSamlpOptionsResponseSignInEndpoint(
        Auth0.MyOrganizationApi.IdpSamlpOptionsResponseSignInEndpoint value
    ) => new("idpSamlpOptionsResponseSignInEndpoint", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "idpSamlpOptionsResponseMetadataUrl"
    /// </summary>
    public bool IsIdpSamlpOptionsResponseMetadataUrl() =>
        Type == "idpSamlpOptionsResponseMetadataUrl";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "idpSamlpOptionsResponseSignInEndpoint"
    /// </summary>
    public bool IsIdpSamlpOptionsResponseSignInEndpoint() =>
        Type == "idpSamlpOptionsResponseSignInEndpoint";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.MyOrganizationApi.IdpSamlpOptionsResponseMetadataUrl"/> if <see cref="Type"/> is 'idpSamlpOptionsResponseMetadataUrl', otherwise throws an exception.
    /// </summary>
    /// <exception cref="MyOrganizationException">Thrown when <see cref="Type"/> is not 'idpSamlpOptionsResponseMetadataUrl'.</exception>
    public Auth0.MyOrganizationApi.IdpSamlpOptionsResponseMetadataUrl AsIdpSamlpOptionsResponseMetadataUrl() =>
        IsIdpSamlpOptionsResponseMetadataUrl()
            ? (Auth0.MyOrganizationApi.IdpSamlpOptionsResponseMetadataUrl)Value!
            : throw new MyOrganizationException(
                "Union type is not 'idpSamlpOptionsResponseMetadataUrl'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.MyOrganizationApi.IdpSamlpOptionsResponseSignInEndpoint"/> if <see cref="Type"/> is 'idpSamlpOptionsResponseSignInEndpoint', otherwise throws an exception.
    /// </summary>
    /// <exception cref="MyOrganizationException">Thrown when <see cref="Type"/> is not 'idpSamlpOptionsResponseSignInEndpoint'.</exception>
    public Auth0.MyOrganizationApi.IdpSamlpOptionsResponseSignInEndpoint AsIdpSamlpOptionsResponseSignInEndpoint() =>
        IsIdpSamlpOptionsResponseSignInEndpoint()
            ? (Auth0.MyOrganizationApi.IdpSamlpOptionsResponseSignInEndpoint)Value!
            : throw new MyOrganizationException(
                "Union type is not 'idpSamlpOptionsResponseSignInEndpoint'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.MyOrganizationApi.IdpSamlpOptionsResponseMetadataUrl"/> and returns true if successful.
    /// </summary>
    public bool TryGetIdpSamlpOptionsResponseMetadataUrl(
        out Auth0.MyOrganizationApi.IdpSamlpOptionsResponseMetadataUrl? value
    )
    {
        if (Type == "idpSamlpOptionsResponseMetadataUrl")
        {
            value = (Auth0.MyOrganizationApi.IdpSamlpOptionsResponseMetadataUrl)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.MyOrganizationApi.IdpSamlpOptionsResponseSignInEndpoint"/> and returns true if successful.
    /// </summary>
    public bool TryGetIdpSamlpOptionsResponseSignInEndpoint(
        out Auth0.MyOrganizationApi.IdpSamlpOptionsResponseSignInEndpoint? value
    )
    {
        if (Type == "idpSamlpOptionsResponseSignInEndpoint")
        {
            value = (Auth0.MyOrganizationApi.IdpSamlpOptionsResponseSignInEndpoint)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.MyOrganizationApi.IdpSamlpOptionsResponseMetadataUrl,
            T
        > onIdpSamlpOptionsResponseMetadataUrl,
        Func<
            Auth0.MyOrganizationApi.IdpSamlpOptionsResponseSignInEndpoint,
            T
        > onIdpSamlpOptionsResponseSignInEndpoint
    )
    {
        return Type switch
        {
            "idpSamlpOptionsResponseMetadataUrl" => onIdpSamlpOptionsResponseMetadataUrl(
                AsIdpSamlpOptionsResponseMetadataUrl()
            ),
            "idpSamlpOptionsResponseSignInEndpoint" => onIdpSamlpOptionsResponseSignInEndpoint(
                AsIdpSamlpOptionsResponseSignInEndpoint()
            ),
            _ => throw new MyOrganizationException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        Action<Auth0.MyOrganizationApi.IdpSamlpOptionsResponseMetadataUrl> onIdpSamlpOptionsResponseMetadataUrl,
        Action<Auth0.MyOrganizationApi.IdpSamlpOptionsResponseSignInEndpoint> onIdpSamlpOptionsResponseSignInEndpoint
    )
    {
        switch (Type)
        {
            case "idpSamlpOptionsResponseMetadataUrl":
                onIdpSamlpOptionsResponseMetadataUrl(AsIdpSamlpOptionsResponseMetadataUrl());
                break;
            case "idpSamlpOptionsResponseSignInEndpoint":
                onIdpSamlpOptionsResponseSignInEndpoint(AsIdpSamlpOptionsResponseSignInEndpoint());
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
        Auth0.MyOrganizationApi.IdpSamlpOptionsResponseMetadataUrl value
    ) => new("idpSamlpOptionsResponseMetadataUrl", value);

    public static implicit operator IdpSamlpOptionsResponse(
        Auth0.MyOrganizationApi.IdpSamlpOptionsResponseSignInEndpoint value
    ) => new("idpSamlpOptionsResponseSignInEndpoint", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<IdpSamlpOptionsResponse>
    {
        public override IdpSamlpOptionsResponse? Read(
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
                        "idpSamlpOptionsResponseMetadataUrl",
                        typeof(Auth0.MyOrganizationApi.IdpSamlpOptionsResponseMetadataUrl)
                    ),
                    (
                        "idpSamlpOptionsResponseSignInEndpoint",
                        typeof(Auth0.MyOrganizationApi.IdpSamlpOptionsResponseSignInEndpoint)
                    ),
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
            global::System.Type typeToConvert,
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
