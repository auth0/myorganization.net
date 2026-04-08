// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.MyOrganizationApi.Core;

namespace Auth0.MyOrganizationApi;

[JsonConverter(typeof(IdpKnownRequest.JsonConverter))]
[Serializable]
public class IdpKnownRequest
{
    private IdpKnownRequest(string type, object? value)
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
    /// Factory method to create a union from a Auth0.MyOrganizationApi.IdpAdfsRequest value.
    /// </summary>
    public static IdpKnownRequest FromIdpAdfsRequest(
        Auth0.MyOrganizationApi.IdpAdfsRequest value
    ) => new("idpAdfsRequest", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.MyOrganizationApi.IdpGoogleAppsRequest value.
    /// </summary>
    public static IdpKnownRequest FromIdpGoogleAppsRequest(
        Auth0.MyOrganizationApi.IdpGoogleAppsRequest value
    ) => new("idpGoogleAppsRequest", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.MyOrganizationApi.IdpOidcRequest value.
    /// </summary>
    public static IdpKnownRequest FromIdpOidcRequest(
        Auth0.MyOrganizationApi.IdpOidcRequest value
    ) => new("idpOidcRequest", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.MyOrganizationApi.IdpOktaRequest value.
    /// </summary>
    public static IdpKnownRequest FromIdpOktaRequest(
        Auth0.MyOrganizationApi.IdpOktaRequest value
    ) => new("idpOktaRequest", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.MyOrganizationApi.IdpPingFederateRequest value.
    /// </summary>
    public static IdpKnownRequest FromIdpPingFederateRequest(
        Auth0.MyOrganizationApi.IdpPingFederateRequest value
    ) => new("idpPingFederateRequest", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.MyOrganizationApi.IdpSamlpRequest value.
    /// </summary>
    public static IdpKnownRequest FromIdpSamlpRequest(
        Auth0.MyOrganizationApi.IdpSamlpRequest value
    ) => new("idpSamlpRequest", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.MyOrganizationApi.IdpWaadRequest value.
    /// </summary>
    public static IdpKnownRequest FromIdpWaadRequest(
        Auth0.MyOrganizationApi.IdpWaadRequest value
    ) => new("idpWaadRequest", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "idpAdfsRequest"
    /// </summary>
    public bool IsIdpAdfsRequest() => Type == "idpAdfsRequest";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "idpGoogleAppsRequest"
    /// </summary>
    public bool IsIdpGoogleAppsRequest() => Type == "idpGoogleAppsRequest";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "idpOidcRequest"
    /// </summary>
    public bool IsIdpOidcRequest() => Type == "idpOidcRequest";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "idpOktaRequest"
    /// </summary>
    public bool IsIdpOktaRequest() => Type == "idpOktaRequest";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "idpPingFederateRequest"
    /// </summary>
    public bool IsIdpPingFederateRequest() => Type == "idpPingFederateRequest";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "idpSamlpRequest"
    /// </summary>
    public bool IsIdpSamlpRequest() => Type == "idpSamlpRequest";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "idpWaadRequest"
    /// </summary>
    public bool IsIdpWaadRequest() => Type == "idpWaadRequest";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.MyOrganizationApi.IdpAdfsRequest"/> if <see cref="Type"/> is 'idpAdfsRequest', otherwise throws an exception.
    /// </summary>
    /// <exception cref="MyOrganizationException">Thrown when <see cref="Type"/> is not 'idpAdfsRequest'.</exception>
    public Auth0.MyOrganizationApi.IdpAdfsRequest AsIdpAdfsRequest() =>
        IsIdpAdfsRequest()
            ? (Auth0.MyOrganizationApi.IdpAdfsRequest)Value!
            : throw new MyOrganizationException("Union type is not 'idpAdfsRequest'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.MyOrganizationApi.IdpGoogleAppsRequest"/> if <see cref="Type"/> is 'idpGoogleAppsRequest', otherwise throws an exception.
    /// </summary>
    /// <exception cref="MyOrganizationException">Thrown when <see cref="Type"/> is not 'idpGoogleAppsRequest'.</exception>
    public Auth0.MyOrganizationApi.IdpGoogleAppsRequest AsIdpGoogleAppsRequest() =>
        IsIdpGoogleAppsRequest()
            ? (Auth0.MyOrganizationApi.IdpGoogleAppsRequest)Value!
            : throw new MyOrganizationException("Union type is not 'idpGoogleAppsRequest'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.MyOrganizationApi.IdpOidcRequest"/> if <see cref="Type"/> is 'idpOidcRequest', otherwise throws an exception.
    /// </summary>
    /// <exception cref="MyOrganizationException">Thrown when <see cref="Type"/> is not 'idpOidcRequest'.</exception>
    public Auth0.MyOrganizationApi.IdpOidcRequest AsIdpOidcRequest() =>
        IsIdpOidcRequest()
            ? (Auth0.MyOrganizationApi.IdpOidcRequest)Value!
            : throw new MyOrganizationException("Union type is not 'idpOidcRequest'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.MyOrganizationApi.IdpOktaRequest"/> if <see cref="Type"/> is 'idpOktaRequest', otherwise throws an exception.
    /// </summary>
    /// <exception cref="MyOrganizationException">Thrown when <see cref="Type"/> is not 'idpOktaRequest'.</exception>
    public Auth0.MyOrganizationApi.IdpOktaRequest AsIdpOktaRequest() =>
        IsIdpOktaRequest()
            ? (Auth0.MyOrganizationApi.IdpOktaRequest)Value!
            : throw new MyOrganizationException("Union type is not 'idpOktaRequest'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.MyOrganizationApi.IdpPingFederateRequest"/> if <see cref="Type"/> is 'idpPingFederateRequest', otherwise throws an exception.
    /// </summary>
    /// <exception cref="MyOrganizationException">Thrown when <see cref="Type"/> is not 'idpPingFederateRequest'.</exception>
    public Auth0.MyOrganizationApi.IdpPingFederateRequest AsIdpPingFederateRequest() =>
        IsIdpPingFederateRequest()
            ? (Auth0.MyOrganizationApi.IdpPingFederateRequest)Value!
            : throw new MyOrganizationException("Union type is not 'idpPingFederateRequest'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.MyOrganizationApi.IdpSamlpRequest"/> if <see cref="Type"/> is 'idpSamlpRequest', otherwise throws an exception.
    /// </summary>
    /// <exception cref="MyOrganizationException">Thrown when <see cref="Type"/> is not 'idpSamlpRequest'.</exception>
    public Auth0.MyOrganizationApi.IdpSamlpRequest AsIdpSamlpRequest() =>
        IsIdpSamlpRequest()
            ? (Auth0.MyOrganizationApi.IdpSamlpRequest)Value!
            : throw new MyOrganizationException("Union type is not 'idpSamlpRequest'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.MyOrganizationApi.IdpWaadRequest"/> if <see cref="Type"/> is 'idpWaadRequest', otherwise throws an exception.
    /// </summary>
    /// <exception cref="MyOrganizationException">Thrown when <see cref="Type"/> is not 'idpWaadRequest'.</exception>
    public Auth0.MyOrganizationApi.IdpWaadRequest AsIdpWaadRequest() =>
        IsIdpWaadRequest()
            ? (Auth0.MyOrganizationApi.IdpWaadRequest)Value!
            : throw new MyOrganizationException("Union type is not 'idpWaadRequest'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.MyOrganizationApi.IdpAdfsRequest"/> and returns true if successful.
    /// </summary>
    public bool TryGetIdpAdfsRequest(out Auth0.MyOrganizationApi.IdpAdfsRequest? value)
    {
        if (Type == "idpAdfsRequest")
        {
            value = (Auth0.MyOrganizationApi.IdpAdfsRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.MyOrganizationApi.IdpGoogleAppsRequest"/> and returns true if successful.
    /// </summary>
    public bool TryGetIdpGoogleAppsRequest(out Auth0.MyOrganizationApi.IdpGoogleAppsRequest? value)
    {
        if (Type == "idpGoogleAppsRequest")
        {
            value = (Auth0.MyOrganizationApi.IdpGoogleAppsRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.MyOrganizationApi.IdpOidcRequest"/> and returns true if successful.
    /// </summary>
    public bool TryGetIdpOidcRequest(out Auth0.MyOrganizationApi.IdpOidcRequest? value)
    {
        if (Type == "idpOidcRequest")
        {
            value = (Auth0.MyOrganizationApi.IdpOidcRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.MyOrganizationApi.IdpOktaRequest"/> and returns true if successful.
    /// </summary>
    public bool TryGetIdpOktaRequest(out Auth0.MyOrganizationApi.IdpOktaRequest? value)
    {
        if (Type == "idpOktaRequest")
        {
            value = (Auth0.MyOrganizationApi.IdpOktaRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.MyOrganizationApi.IdpPingFederateRequest"/> and returns true if successful.
    /// </summary>
    public bool TryGetIdpPingFederateRequest(
        out Auth0.MyOrganizationApi.IdpPingFederateRequest? value
    )
    {
        if (Type == "idpPingFederateRequest")
        {
            value = (Auth0.MyOrganizationApi.IdpPingFederateRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.MyOrganizationApi.IdpSamlpRequest"/> and returns true if successful.
    /// </summary>
    public bool TryGetIdpSamlpRequest(out Auth0.MyOrganizationApi.IdpSamlpRequest? value)
    {
        if (Type == "idpSamlpRequest")
        {
            value = (Auth0.MyOrganizationApi.IdpSamlpRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.MyOrganizationApi.IdpWaadRequest"/> and returns true if successful.
    /// </summary>
    public bool TryGetIdpWaadRequest(out Auth0.MyOrganizationApi.IdpWaadRequest? value)
    {
        if (Type == "idpWaadRequest")
        {
            value = (Auth0.MyOrganizationApi.IdpWaadRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Auth0.MyOrganizationApi.IdpAdfsRequest, T> onIdpAdfsRequest,
        Func<Auth0.MyOrganizationApi.IdpGoogleAppsRequest, T> onIdpGoogleAppsRequest,
        Func<Auth0.MyOrganizationApi.IdpOidcRequest, T> onIdpOidcRequest,
        Func<Auth0.MyOrganizationApi.IdpOktaRequest, T> onIdpOktaRequest,
        Func<Auth0.MyOrganizationApi.IdpPingFederateRequest, T> onIdpPingFederateRequest,
        Func<Auth0.MyOrganizationApi.IdpSamlpRequest, T> onIdpSamlpRequest,
        Func<Auth0.MyOrganizationApi.IdpWaadRequest, T> onIdpWaadRequest
    )
    {
        return Type switch
        {
            "idpAdfsRequest" => onIdpAdfsRequest(AsIdpAdfsRequest()),
            "idpGoogleAppsRequest" => onIdpGoogleAppsRequest(AsIdpGoogleAppsRequest()),
            "idpOidcRequest" => onIdpOidcRequest(AsIdpOidcRequest()),
            "idpOktaRequest" => onIdpOktaRequest(AsIdpOktaRequest()),
            "idpPingFederateRequest" => onIdpPingFederateRequest(AsIdpPingFederateRequest()),
            "idpSamlpRequest" => onIdpSamlpRequest(AsIdpSamlpRequest()),
            "idpWaadRequest" => onIdpWaadRequest(AsIdpWaadRequest()),
            _ => throw new MyOrganizationException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        Action<Auth0.MyOrganizationApi.IdpAdfsRequest> onIdpAdfsRequest,
        Action<Auth0.MyOrganizationApi.IdpGoogleAppsRequest> onIdpGoogleAppsRequest,
        Action<Auth0.MyOrganizationApi.IdpOidcRequest> onIdpOidcRequest,
        Action<Auth0.MyOrganizationApi.IdpOktaRequest> onIdpOktaRequest,
        Action<Auth0.MyOrganizationApi.IdpPingFederateRequest> onIdpPingFederateRequest,
        Action<Auth0.MyOrganizationApi.IdpSamlpRequest> onIdpSamlpRequest,
        Action<Auth0.MyOrganizationApi.IdpWaadRequest> onIdpWaadRequest
    )
    {
        switch (Type)
        {
            case "idpAdfsRequest":
                onIdpAdfsRequest(AsIdpAdfsRequest());
                break;
            case "idpGoogleAppsRequest":
                onIdpGoogleAppsRequest(AsIdpGoogleAppsRequest());
                break;
            case "idpOidcRequest":
                onIdpOidcRequest(AsIdpOidcRequest());
                break;
            case "idpOktaRequest":
                onIdpOktaRequest(AsIdpOktaRequest());
                break;
            case "idpPingFederateRequest":
                onIdpPingFederateRequest(AsIdpPingFederateRequest());
                break;
            case "idpSamlpRequest":
                onIdpSamlpRequest(AsIdpSamlpRequest());
                break;
            case "idpWaadRequest":
                onIdpWaadRequest(AsIdpWaadRequest());
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
        if (obj is not IdpKnownRequest other)
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

    public static implicit operator IdpKnownRequest(Auth0.MyOrganizationApi.IdpAdfsRequest value) =>
        new("idpAdfsRequest", value);

    public static implicit operator IdpKnownRequest(
        Auth0.MyOrganizationApi.IdpGoogleAppsRequest value
    ) => new("idpGoogleAppsRequest", value);

    public static implicit operator IdpKnownRequest(Auth0.MyOrganizationApi.IdpOidcRequest value) =>
        new("idpOidcRequest", value);

    public static implicit operator IdpKnownRequest(Auth0.MyOrganizationApi.IdpOktaRequest value) =>
        new("idpOktaRequest", value);

    public static implicit operator IdpKnownRequest(
        Auth0.MyOrganizationApi.IdpPingFederateRequest value
    ) => new("idpPingFederateRequest", value);

    public static implicit operator IdpKnownRequest(
        Auth0.MyOrganizationApi.IdpSamlpRequest value
    ) => new("idpSamlpRequest", value);

    public static implicit operator IdpKnownRequest(Auth0.MyOrganizationApi.IdpWaadRequest value) =>
        new("idpWaadRequest", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<IdpKnownRequest>
    {
        public override IdpKnownRequest? Read(
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
                    ("idpAdfsRequest", typeof(Auth0.MyOrganizationApi.IdpAdfsRequest)),
                    ("idpGoogleAppsRequest", typeof(Auth0.MyOrganizationApi.IdpGoogleAppsRequest)),
                    ("idpOidcRequest", typeof(Auth0.MyOrganizationApi.IdpOidcRequest)),
                    ("idpOktaRequest", typeof(Auth0.MyOrganizationApi.IdpOktaRequest)),
                    (
                        "idpPingFederateRequest",
                        typeof(Auth0.MyOrganizationApi.IdpPingFederateRequest)
                    ),
                    ("idpSamlpRequest", typeof(Auth0.MyOrganizationApi.IdpSamlpRequest)),
                    ("idpWaadRequest", typeof(Auth0.MyOrganizationApi.IdpWaadRequest)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            IdpKnownRequest result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into IdpKnownRequest"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            IdpKnownRequest value,
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
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override IdpKnownRequest ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            IdpKnownRequest result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            IdpKnownRequest value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
