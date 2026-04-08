// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.MyOrganizationApi.Core;

namespace Auth0.MyOrganizationApi;

[JsonConverter(typeof(IdpKnownResponse.JsonConverter))]
[Serializable]
public class IdpKnownResponse
{
    private IdpKnownResponse(string type, object? value)
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
    /// Factory method to create a union from a Auth0.MyOrganizationApi.IdpAdfsResponse value.
    /// </summary>
    public static IdpKnownResponse FromIdpAdfsResponse(
        Auth0.MyOrganizationApi.IdpAdfsResponse value
    ) => new("idpAdfsResponse", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.MyOrganizationApi.IdpGoogleAppsResponse value.
    /// </summary>
    public static IdpKnownResponse FromIdpGoogleAppsResponse(
        Auth0.MyOrganizationApi.IdpGoogleAppsResponse value
    ) => new("idpGoogleAppsResponse", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.MyOrganizationApi.IdpOidcResponse value.
    /// </summary>
    public static IdpKnownResponse FromIdpOidcResponse(
        Auth0.MyOrganizationApi.IdpOidcResponse value
    ) => new("idpOidcResponse", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.MyOrganizationApi.IdpOktaResponse value.
    /// </summary>
    public static IdpKnownResponse FromIdpOktaResponse(
        Auth0.MyOrganizationApi.IdpOktaResponse value
    ) => new("idpOktaResponse", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.MyOrganizationApi.IdpPingFederateResponse value.
    /// </summary>
    public static IdpKnownResponse FromIdpPingFederateResponse(
        Auth0.MyOrganizationApi.IdpPingFederateResponse value
    ) => new("idpPingFederateResponse", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.MyOrganizationApi.IdpSamlpResponse value.
    /// </summary>
    public static IdpKnownResponse FromIdpSamlpResponse(
        Auth0.MyOrganizationApi.IdpSamlpResponse value
    ) => new("idpSamlpResponse", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.MyOrganizationApi.IdpWaadResponse value.
    /// </summary>
    public static IdpKnownResponse FromIdpWaadResponse(
        Auth0.MyOrganizationApi.IdpWaadResponse value
    ) => new("idpWaadResponse", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "idpAdfsResponse"
    /// </summary>
    public bool IsIdpAdfsResponse() => Type == "idpAdfsResponse";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "idpGoogleAppsResponse"
    /// </summary>
    public bool IsIdpGoogleAppsResponse() => Type == "idpGoogleAppsResponse";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "idpOidcResponse"
    /// </summary>
    public bool IsIdpOidcResponse() => Type == "idpOidcResponse";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "idpOktaResponse"
    /// </summary>
    public bool IsIdpOktaResponse() => Type == "idpOktaResponse";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "idpPingFederateResponse"
    /// </summary>
    public bool IsIdpPingFederateResponse() => Type == "idpPingFederateResponse";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "idpSamlpResponse"
    /// </summary>
    public bool IsIdpSamlpResponse() => Type == "idpSamlpResponse";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "idpWaadResponse"
    /// </summary>
    public bool IsIdpWaadResponse() => Type == "idpWaadResponse";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.MyOrganizationApi.IdpAdfsResponse"/> if <see cref="Type"/> is 'idpAdfsResponse', otherwise throws an exception.
    /// </summary>
    /// <exception cref="MyOrganizationException">Thrown when <see cref="Type"/> is not 'idpAdfsResponse'.</exception>
    public Auth0.MyOrganizationApi.IdpAdfsResponse AsIdpAdfsResponse() =>
        IsIdpAdfsResponse()
            ? (Auth0.MyOrganizationApi.IdpAdfsResponse)Value!
            : throw new MyOrganizationException("Union type is not 'idpAdfsResponse'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.MyOrganizationApi.IdpGoogleAppsResponse"/> if <see cref="Type"/> is 'idpGoogleAppsResponse', otherwise throws an exception.
    /// </summary>
    /// <exception cref="MyOrganizationException">Thrown when <see cref="Type"/> is not 'idpGoogleAppsResponse'.</exception>
    public Auth0.MyOrganizationApi.IdpGoogleAppsResponse AsIdpGoogleAppsResponse() =>
        IsIdpGoogleAppsResponse()
            ? (Auth0.MyOrganizationApi.IdpGoogleAppsResponse)Value!
            : throw new MyOrganizationException("Union type is not 'idpGoogleAppsResponse'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.MyOrganizationApi.IdpOidcResponse"/> if <see cref="Type"/> is 'idpOidcResponse', otherwise throws an exception.
    /// </summary>
    /// <exception cref="MyOrganizationException">Thrown when <see cref="Type"/> is not 'idpOidcResponse'.</exception>
    public Auth0.MyOrganizationApi.IdpOidcResponse AsIdpOidcResponse() =>
        IsIdpOidcResponse()
            ? (Auth0.MyOrganizationApi.IdpOidcResponse)Value!
            : throw new MyOrganizationException("Union type is not 'idpOidcResponse'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.MyOrganizationApi.IdpOktaResponse"/> if <see cref="Type"/> is 'idpOktaResponse', otherwise throws an exception.
    /// </summary>
    /// <exception cref="MyOrganizationException">Thrown when <see cref="Type"/> is not 'idpOktaResponse'.</exception>
    public Auth0.MyOrganizationApi.IdpOktaResponse AsIdpOktaResponse() =>
        IsIdpOktaResponse()
            ? (Auth0.MyOrganizationApi.IdpOktaResponse)Value!
            : throw new MyOrganizationException("Union type is not 'idpOktaResponse'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.MyOrganizationApi.IdpPingFederateResponse"/> if <see cref="Type"/> is 'idpPingFederateResponse', otherwise throws an exception.
    /// </summary>
    /// <exception cref="MyOrganizationException">Thrown when <see cref="Type"/> is not 'idpPingFederateResponse'.</exception>
    public Auth0.MyOrganizationApi.IdpPingFederateResponse AsIdpPingFederateResponse() =>
        IsIdpPingFederateResponse()
            ? (Auth0.MyOrganizationApi.IdpPingFederateResponse)Value!
            : throw new MyOrganizationException("Union type is not 'idpPingFederateResponse'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.MyOrganizationApi.IdpSamlpResponse"/> if <see cref="Type"/> is 'idpSamlpResponse', otherwise throws an exception.
    /// </summary>
    /// <exception cref="MyOrganizationException">Thrown when <see cref="Type"/> is not 'idpSamlpResponse'.</exception>
    public Auth0.MyOrganizationApi.IdpSamlpResponse AsIdpSamlpResponse() =>
        IsIdpSamlpResponse()
            ? (Auth0.MyOrganizationApi.IdpSamlpResponse)Value!
            : throw new MyOrganizationException("Union type is not 'idpSamlpResponse'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.MyOrganizationApi.IdpWaadResponse"/> if <see cref="Type"/> is 'idpWaadResponse', otherwise throws an exception.
    /// </summary>
    /// <exception cref="MyOrganizationException">Thrown when <see cref="Type"/> is not 'idpWaadResponse'.</exception>
    public Auth0.MyOrganizationApi.IdpWaadResponse AsIdpWaadResponse() =>
        IsIdpWaadResponse()
            ? (Auth0.MyOrganizationApi.IdpWaadResponse)Value!
            : throw new MyOrganizationException("Union type is not 'idpWaadResponse'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.MyOrganizationApi.IdpAdfsResponse"/> and returns true if successful.
    /// </summary>
    public bool TryGetIdpAdfsResponse(out Auth0.MyOrganizationApi.IdpAdfsResponse? value)
    {
        if (Type == "idpAdfsResponse")
        {
            value = (Auth0.MyOrganizationApi.IdpAdfsResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.MyOrganizationApi.IdpGoogleAppsResponse"/> and returns true if successful.
    /// </summary>
    public bool TryGetIdpGoogleAppsResponse(
        out Auth0.MyOrganizationApi.IdpGoogleAppsResponse? value
    )
    {
        if (Type == "idpGoogleAppsResponse")
        {
            value = (Auth0.MyOrganizationApi.IdpGoogleAppsResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.MyOrganizationApi.IdpOidcResponse"/> and returns true if successful.
    /// </summary>
    public bool TryGetIdpOidcResponse(out Auth0.MyOrganizationApi.IdpOidcResponse? value)
    {
        if (Type == "idpOidcResponse")
        {
            value = (Auth0.MyOrganizationApi.IdpOidcResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.MyOrganizationApi.IdpOktaResponse"/> and returns true if successful.
    /// </summary>
    public bool TryGetIdpOktaResponse(out Auth0.MyOrganizationApi.IdpOktaResponse? value)
    {
        if (Type == "idpOktaResponse")
        {
            value = (Auth0.MyOrganizationApi.IdpOktaResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.MyOrganizationApi.IdpPingFederateResponse"/> and returns true if successful.
    /// </summary>
    public bool TryGetIdpPingFederateResponse(
        out Auth0.MyOrganizationApi.IdpPingFederateResponse? value
    )
    {
        if (Type == "idpPingFederateResponse")
        {
            value = (Auth0.MyOrganizationApi.IdpPingFederateResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.MyOrganizationApi.IdpSamlpResponse"/> and returns true if successful.
    /// </summary>
    public bool TryGetIdpSamlpResponse(out Auth0.MyOrganizationApi.IdpSamlpResponse? value)
    {
        if (Type == "idpSamlpResponse")
        {
            value = (Auth0.MyOrganizationApi.IdpSamlpResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.MyOrganizationApi.IdpWaadResponse"/> and returns true if successful.
    /// </summary>
    public bool TryGetIdpWaadResponse(out Auth0.MyOrganizationApi.IdpWaadResponse? value)
    {
        if (Type == "idpWaadResponse")
        {
            value = (Auth0.MyOrganizationApi.IdpWaadResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Auth0.MyOrganizationApi.IdpAdfsResponse, T> onIdpAdfsResponse,
        Func<Auth0.MyOrganizationApi.IdpGoogleAppsResponse, T> onIdpGoogleAppsResponse,
        Func<Auth0.MyOrganizationApi.IdpOidcResponse, T> onIdpOidcResponse,
        Func<Auth0.MyOrganizationApi.IdpOktaResponse, T> onIdpOktaResponse,
        Func<Auth0.MyOrganizationApi.IdpPingFederateResponse, T> onIdpPingFederateResponse,
        Func<Auth0.MyOrganizationApi.IdpSamlpResponse, T> onIdpSamlpResponse,
        Func<Auth0.MyOrganizationApi.IdpWaadResponse, T> onIdpWaadResponse
    )
    {
        return Type switch
        {
            "idpAdfsResponse" => onIdpAdfsResponse(AsIdpAdfsResponse()),
            "idpGoogleAppsResponse" => onIdpGoogleAppsResponse(AsIdpGoogleAppsResponse()),
            "idpOidcResponse" => onIdpOidcResponse(AsIdpOidcResponse()),
            "idpOktaResponse" => onIdpOktaResponse(AsIdpOktaResponse()),
            "idpPingFederateResponse" => onIdpPingFederateResponse(AsIdpPingFederateResponse()),
            "idpSamlpResponse" => onIdpSamlpResponse(AsIdpSamlpResponse()),
            "idpWaadResponse" => onIdpWaadResponse(AsIdpWaadResponse()),
            _ => throw new MyOrganizationException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        Action<Auth0.MyOrganizationApi.IdpAdfsResponse> onIdpAdfsResponse,
        Action<Auth0.MyOrganizationApi.IdpGoogleAppsResponse> onIdpGoogleAppsResponse,
        Action<Auth0.MyOrganizationApi.IdpOidcResponse> onIdpOidcResponse,
        Action<Auth0.MyOrganizationApi.IdpOktaResponse> onIdpOktaResponse,
        Action<Auth0.MyOrganizationApi.IdpPingFederateResponse> onIdpPingFederateResponse,
        Action<Auth0.MyOrganizationApi.IdpSamlpResponse> onIdpSamlpResponse,
        Action<Auth0.MyOrganizationApi.IdpWaadResponse> onIdpWaadResponse
    )
    {
        switch (Type)
        {
            case "idpAdfsResponse":
                onIdpAdfsResponse(AsIdpAdfsResponse());
                break;
            case "idpGoogleAppsResponse":
                onIdpGoogleAppsResponse(AsIdpGoogleAppsResponse());
                break;
            case "idpOidcResponse":
                onIdpOidcResponse(AsIdpOidcResponse());
                break;
            case "idpOktaResponse":
                onIdpOktaResponse(AsIdpOktaResponse());
                break;
            case "idpPingFederateResponse":
                onIdpPingFederateResponse(AsIdpPingFederateResponse());
                break;
            case "idpSamlpResponse":
                onIdpSamlpResponse(AsIdpSamlpResponse());
                break;
            case "idpWaadResponse":
                onIdpWaadResponse(AsIdpWaadResponse());
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
        if (obj is not IdpKnownResponse other)
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

    public static implicit operator IdpKnownResponse(
        Auth0.MyOrganizationApi.IdpAdfsResponse value
    ) => new("idpAdfsResponse", value);

    public static implicit operator IdpKnownResponse(
        Auth0.MyOrganizationApi.IdpGoogleAppsResponse value
    ) => new("idpGoogleAppsResponse", value);

    public static implicit operator IdpKnownResponse(
        Auth0.MyOrganizationApi.IdpOidcResponse value
    ) => new("idpOidcResponse", value);

    public static implicit operator IdpKnownResponse(
        Auth0.MyOrganizationApi.IdpOktaResponse value
    ) => new("idpOktaResponse", value);

    public static implicit operator IdpKnownResponse(
        Auth0.MyOrganizationApi.IdpPingFederateResponse value
    ) => new("idpPingFederateResponse", value);

    public static implicit operator IdpKnownResponse(
        Auth0.MyOrganizationApi.IdpSamlpResponse value
    ) => new("idpSamlpResponse", value);

    public static implicit operator IdpKnownResponse(
        Auth0.MyOrganizationApi.IdpWaadResponse value
    ) => new("idpWaadResponse", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<IdpKnownResponse>
    {
        public override IdpKnownResponse? Read(
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
                    ("idpAdfsResponse", typeof(Auth0.MyOrganizationApi.IdpAdfsResponse)),
                    (
                        "idpGoogleAppsResponse",
                        typeof(Auth0.MyOrganizationApi.IdpGoogleAppsResponse)
                    ),
                    ("idpOidcResponse", typeof(Auth0.MyOrganizationApi.IdpOidcResponse)),
                    ("idpOktaResponse", typeof(Auth0.MyOrganizationApi.IdpOktaResponse)),
                    (
                        "idpPingFederateResponse",
                        typeof(Auth0.MyOrganizationApi.IdpPingFederateResponse)
                    ),
                    ("idpSamlpResponse", typeof(Auth0.MyOrganizationApi.IdpSamlpResponse)),
                    ("idpWaadResponse", typeof(Auth0.MyOrganizationApi.IdpWaadResponse)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            IdpKnownResponse result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into IdpKnownResponse"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            IdpKnownResponse value,
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

        public override IdpKnownResponse ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            IdpKnownResponse result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            IdpKnownResponse value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
