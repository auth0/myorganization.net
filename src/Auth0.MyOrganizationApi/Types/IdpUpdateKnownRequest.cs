// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

[JsonConverter(typeof(IdpUpdateKnownRequest.JsonConverter))]
[Serializable]
public class IdpUpdateKnownRequest
{
    private IdpUpdateKnownRequest(string type, object? value)
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
    /// Factory method to create a union from a Auth0.MyOrganizationApi.IdpAdfsUpdateRequest value.
    /// </summary>
    public static IdpUpdateKnownRequest FromIdpAdfsUpdateRequest(
        Auth0.MyOrganizationApi.IdpAdfsUpdateRequest value
    ) => new("idpAdfsUpdateRequest", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.MyOrganizationApi.IdpGoogleAppsUpdateRequest value.
    /// </summary>
    public static IdpUpdateKnownRequest FromIdpGoogleAppsUpdateRequest(
        Auth0.MyOrganizationApi.IdpGoogleAppsUpdateRequest value
    ) => new("idpGoogleAppsUpdateRequest", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.MyOrganizationApi.IdpOidcUpdateRequest value.
    /// </summary>
    public static IdpUpdateKnownRequest FromIdpOidcUpdateRequest(
        Auth0.MyOrganizationApi.IdpOidcUpdateRequest value
    ) => new("idpOidcUpdateRequest", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.MyOrganizationApi.IdpOktaUpdateRequest value.
    /// </summary>
    public static IdpUpdateKnownRequest FromIdpOktaUpdateRequest(
        Auth0.MyOrganizationApi.IdpOktaUpdateRequest value
    ) => new("idpOktaUpdateRequest", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.MyOrganizationApi.IdpPingFederateUpdateRequest value.
    /// </summary>
    public static IdpUpdateKnownRequest FromIdpPingFederateUpdateRequest(
        Auth0.MyOrganizationApi.IdpPingFederateUpdateRequest value
    ) => new("idpPingFederateUpdateRequest", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.MyOrganizationApi.IdpSamlpUpdateRequest value.
    /// </summary>
    public static IdpUpdateKnownRequest FromIdpSamlpUpdateRequest(
        Auth0.MyOrganizationApi.IdpSamlpUpdateRequest value
    ) => new("idpSamlpUpdateRequest", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.MyOrganizationApi.IdpWaadUpdateRequest value.
    /// </summary>
    public static IdpUpdateKnownRequest FromIdpWaadUpdateRequest(
        Auth0.MyOrganizationApi.IdpWaadUpdateRequest value
    ) => new("idpWaadUpdateRequest", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "idpAdfsUpdateRequest"
    /// </summary>
    public bool IsIdpAdfsUpdateRequest() => Type == "idpAdfsUpdateRequest";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "idpGoogleAppsUpdateRequest"
    /// </summary>
    public bool IsIdpGoogleAppsUpdateRequest() => Type == "idpGoogleAppsUpdateRequest";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "idpOidcUpdateRequest"
    /// </summary>
    public bool IsIdpOidcUpdateRequest() => Type == "idpOidcUpdateRequest";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "idpOktaUpdateRequest"
    /// </summary>
    public bool IsIdpOktaUpdateRequest() => Type == "idpOktaUpdateRequest";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "idpPingFederateUpdateRequest"
    /// </summary>
    public bool IsIdpPingFederateUpdateRequest() => Type == "idpPingFederateUpdateRequest";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "idpSamlpUpdateRequest"
    /// </summary>
    public bool IsIdpSamlpUpdateRequest() => Type == "idpSamlpUpdateRequest";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "idpWaadUpdateRequest"
    /// </summary>
    public bool IsIdpWaadUpdateRequest() => Type == "idpWaadUpdateRequest";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.MyOrganizationApi.IdpAdfsUpdateRequest"/> if <see cref="Type"/> is 'idpAdfsUpdateRequest', otherwise throws an exception.
    /// </summary>
    /// <exception cref="MyOrganizationException">Thrown when <see cref="Type"/> is not 'idpAdfsUpdateRequest'.</exception>
    public Auth0.MyOrganizationApi.IdpAdfsUpdateRequest AsIdpAdfsUpdateRequest() =>
        IsIdpAdfsUpdateRequest()
            ? (Auth0.MyOrganizationApi.IdpAdfsUpdateRequest)Value!
            : throw new MyOrganizationException("Union type is not 'idpAdfsUpdateRequest'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.MyOrganizationApi.IdpGoogleAppsUpdateRequest"/> if <see cref="Type"/> is 'idpGoogleAppsUpdateRequest', otherwise throws an exception.
    /// </summary>
    /// <exception cref="MyOrganizationException">Thrown when <see cref="Type"/> is not 'idpGoogleAppsUpdateRequest'.</exception>
    public Auth0.MyOrganizationApi.IdpGoogleAppsUpdateRequest AsIdpGoogleAppsUpdateRequest() =>
        IsIdpGoogleAppsUpdateRequest()
            ? (Auth0.MyOrganizationApi.IdpGoogleAppsUpdateRequest)Value!
            : throw new MyOrganizationException("Union type is not 'idpGoogleAppsUpdateRequest'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.MyOrganizationApi.IdpOidcUpdateRequest"/> if <see cref="Type"/> is 'idpOidcUpdateRequest', otherwise throws an exception.
    /// </summary>
    /// <exception cref="MyOrganizationException">Thrown when <see cref="Type"/> is not 'idpOidcUpdateRequest'.</exception>
    public Auth0.MyOrganizationApi.IdpOidcUpdateRequest AsIdpOidcUpdateRequest() =>
        IsIdpOidcUpdateRequest()
            ? (Auth0.MyOrganizationApi.IdpOidcUpdateRequest)Value!
            : throw new MyOrganizationException("Union type is not 'idpOidcUpdateRequest'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.MyOrganizationApi.IdpOktaUpdateRequest"/> if <see cref="Type"/> is 'idpOktaUpdateRequest', otherwise throws an exception.
    /// </summary>
    /// <exception cref="MyOrganizationException">Thrown when <see cref="Type"/> is not 'idpOktaUpdateRequest'.</exception>
    public Auth0.MyOrganizationApi.IdpOktaUpdateRequest AsIdpOktaUpdateRequest() =>
        IsIdpOktaUpdateRequest()
            ? (Auth0.MyOrganizationApi.IdpOktaUpdateRequest)Value!
            : throw new MyOrganizationException("Union type is not 'idpOktaUpdateRequest'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.MyOrganizationApi.IdpPingFederateUpdateRequest"/> if <see cref="Type"/> is 'idpPingFederateUpdateRequest', otherwise throws an exception.
    /// </summary>
    /// <exception cref="MyOrganizationException">Thrown when <see cref="Type"/> is not 'idpPingFederateUpdateRequest'.</exception>
    public Auth0.MyOrganizationApi.IdpPingFederateUpdateRequest AsIdpPingFederateUpdateRequest() =>
        IsIdpPingFederateUpdateRequest()
            ? (Auth0.MyOrganizationApi.IdpPingFederateUpdateRequest)Value!
            : throw new MyOrganizationException("Union type is not 'idpPingFederateUpdateRequest'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.MyOrganizationApi.IdpSamlpUpdateRequest"/> if <see cref="Type"/> is 'idpSamlpUpdateRequest', otherwise throws an exception.
    /// </summary>
    /// <exception cref="MyOrganizationException">Thrown when <see cref="Type"/> is not 'idpSamlpUpdateRequest'.</exception>
    public Auth0.MyOrganizationApi.IdpSamlpUpdateRequest AsIdpSamlpUpdateRequest() =>
        IsIdpSamlpUpdateRequest()
            ? (Auth0.MyOrganizationApi.IdpSamlpUpdateRequest)Value!
            : throw new MyOrganizationException("Union type is not 'idpSamlpUpdateRequest'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.MyOrganizationApi.IdpWaadUpdateRequest"/> if <see cref="Type"/> is 'idpWaadUpdateRequest', otherwise throws an exception.
    /// </summary>
    /// <exception cref="MyOrganizationException">Thrown when <see cref="Type"/> is not 'idpWaadUpdateRequest'.</exception>
    public Auth0.MyOrganizationApi.IdpWaadUpdateRequest AsIdpWaadUpdateRequest() =>
        IsIdpWaadUpdateRequest()
            ? (Auth0.MyOrganizationApi.IdpWaadUpdateRequest)Value!
            : throw new MyOrganizationException("Union type is not 'idpWaadUpdateRequest'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.MyOrganizationApi.IdpAdfsUpdateRequest"/> and returns true if successful.
    /// </summary>
    public bool TryGetIdpAdfsUpdateRequest(out Auth0.MyOrganizationApi.IdpAdfsUpdateRequest? value)
    {
        if (Type == "idpAdfsUpdateRequest")
        {
            value = (Auth0.MyOrganizationApi.IdpAdfsUpdateRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.MyOrganizationApi.IdpGoogleAppsUpdateRequest"/> and returns true if successful.
    /// </summary>
    public bool TryGetIdpGoogleAppsUpdateRequest(
        out Auth0.MyOrganizationApi.IdpGoogleAppsUpdateRequest? value
    )
    {
        if (Type == "idpGoogleAppsUpdateRequest")
        {
            value = (Auth0.MyOrganizationApi.IdpGoogleAppsUpdateRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.MyOrganizationApi.IdpOidcUpdateRequest"/> and returns true if successful.
    /// </summary>
    public bool TryGetIdpOidcUpdateRequest(out Auth0.MyOrganizationApi.IdpOidcUpdateRequest? value)
    {
        if (Type == "idpOidcUpdateRequest")
        {
            value = (Auth0.MyOrganizationApi.IdpOidcUpdateRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.MyOrganizationApi.IdpOktaUpdateRequest"/> and returns true if successful.
    /// </summary>
    public bool TryGetIdpOktaUpdateRequest(out Auth0.MyOrganizationApi.IdpOktaUpdateRequest? value)
    {
        if (Type == "idpOktaUpdateRequest")
        {
            value = (Auth0.MyOrganizationApi.IdpOktaUpdateRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.MyOrganizationApi.IdpPingFederateUpdateRequest"/> and returns true if successful.
    /// </summary>
    public bool TryGetIdpPingFederateUpdateRequest(
        out Auth0.MyOrganizationApi.IdpPingFederateUpdateRequest? value
    )
    {
        if (Type == "idpPingFederateUpdateRequest")
        {
            value = (Auth0.MyOrganizationApi.IdpPingFederateUpdateRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.MyOrganizationApi.IdpSamlpUpdateRequest"/> and returns true if successful.
    /// </summary>
    public bool TryGetIdpSamlpUpdateRequest(
        out Auth0.MyOrganizationApi.IdpSamlpUpdateRequest? value
    )
    {
        if (Type == "idpSamlpUpdateRequest")
        {
            value = (Auth0.MyOrganizationApi.IdpSamlpUpdateRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.MyOrganizationApi.IdpWaadUpdateRequest"/> and returns true if successful.
    /// </summary>
    public bool TryGetIdpWaadUpdateRequest(out Auth0.MyOrganizationApi.IdpWaadUpdateRequest? value)
    {
        if (Type == "idpWaadUpdateRequest")
        {
            value = (Auth0.MyOrganizationApi.IdpWaadUpdateRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Auth0.MyOrganizationApi.IdpAdfsUpdateRequest, T> onIdpAdfsUpdateRequest,
        Func<Auth0.MyOrganizationApi.IdpGoogleAppsUpdateRequest, T> onIdpGoogleAppsUpdateRequest,
        Func<Auth0.MyOrganizationApi.IdpOidcUpdateRequest, T> onIdpOidcUpdateRequest,
        Func<Auth0.MyOrganizationApi.IdpOktaUpdateRequest, T> onIdpOktaUpdateRequest,
        Func<
            Auth0.MyOrganizationApi.IdpPingFederateUpdateRequest,
            T
        > onIdpPingFederateUpdateRequest,
        Func<Auth0.MyOrganizationApi.IdpSamlpUpdateRequest, T> onIdpSamlpUpdateRequest,
        Func<Auth0.MyOrganizationApi.IdpWaadUpdateRequest, T> onIdpWaadUpdateRequest
    )
    {
        return Type switch
        {
            "idpAdfsUpdateRequest" => onIdpAdfsUpdateRequest(AsIdpAdfsUpdateRequest()),
            "idpGoogleAppsUpdateRequest" => onIdpGoogleAppsUpdateRequest(
                AsIdpGoogleAppsUpdateRequest()
            ),
            "idpOidcUpdateRequest" => onIdpOidcUpdateRequest(AsIdpOidcUpdateRequest()),
            "idpOktaUpdateRequest" => onIdpOktaUpdateRequest(AsIdpOktaUpdateRequest()),
            "idpPingFederateUpdateRequest" => onIdpPingFederateUpdateRequest(
                AsIdpPingFederateUpdateRequest()
            ),
            "idpSamlpUpdateRequest" => onIdpSamlpUpdateRequest(AsIdpSamlpUpdateRequest()),
            "idpWaadUpdateRequest" => onIdpWaadUpdateRequest(AsIdpWaadUpdateRequest()),
            _ => throw new MyOrganizationException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        Action<Auth0.MyOrganizationApi.IdpAdfsUpdateRequest> onIdpAdfsUpdateRequest,
        Action<Auth0.MyOrganizationApi.IdpGoogleAppsUpdateRequest> onIdpGoogleAppsUpdateRequest,
        Action<Auth0.MyOrganizationApi.IdpOidcUpdateRequest> onIdpOidcUpdateRequest,
        Action<Auth0.MyOrganizationApi.IdpOktaUpdateRequest> onIdpOktaUpdateRequest,
        Action<Auth0.MyOrganizationApi.IdpPingFederateUpdateRequest> onIdpPingFederateUpdateRequest,
        Action<Auth0.MyOrganizationApi.IdpSamlpUpdateRequest> onIdpSamlpUpdateRequest,
        Action<Auth0.MyOrganizationApi.IdpWaadUpdateRequest> onIdpWaadUpdateRequest
    )
    {
        switch (Type)
        {
            case "idpAdfsUpdateRequest":
                onIdpAdfsUpdateRequest(AsIdpAdfsUpdateRequest());
                break;
            case "idpGoogleAppsUpdateRequest":
                onIdpGoogleAppsUpdateRequest(AsIdpGoogleAppsUpdateRequest());
                break;
            case "idpOidcUpdateRequest":
                onIdpOidcUpdateRequest(AsIdpOidcUpdateRequest());
                break;
            case "idpOktaUpdateRequest":
                onIdpOktaUpdateRequest(AsIdpOktaUpdateRequest());
                break;
            case "idpPingFederateUpdateRequest":
                onIdpPingFederateUpdateRequest(AsIdpPingFederateUpdateRequest());
                break;
            case "idpSamlpUpdateRequest":
                onIdpSamlpUpdateRequest(AsIdpSamlpUpdateRequest());
                break;
            case "idpWaadUpdateRequest":
                onIdpWaadUpdateRequest(AsIdpWaadUpdateRequest());
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
        if (obj is not IdpUpdateKnownRequest other)
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

    public static implicit operator IdpUpdateKnownRequest(
        Auth0.MyOrganizationApi.IdpAdfsUpdateRequest value
    ) => new("idpAdfsUpdateRequest", value);

    public static implicit operator IdpUpdateKnownRequest(
        Auth0.MyOrganizationApi.IdpGoogleAppsUpdateRequest value
    ) => new("idpGoogleAppsUpdateRequest", value);

    public static implicit operator IdpUpdateKnownRequest(
        Auth0.MyOrganizationApi.IdpOidcUpdateRequest value
    ) => new("idpOidcUpdateRequest", value);

    public static implicit operator IdpUpdateKnownRequest(
        Auth0.MyOrganizationApi.IdpOktaUpdateRequest value
    ) => new("idpOktaUpdateRequest", value);

    public static implicit operator IdpUpdateKnownRequest(
        Auth0.MyOrganizationApi.IdpPingFederateUpdateRequest value
    ) => new("idpPingFederateUpdateRequest", value);

    public static implicit operator IdpUpdateKnownRequest(
        Auth0.MyOrganizationApi.IdpSamlpUpdateRequest value
    ) => new("idpSamlpUpdateRequest", value);

    public static implicit operator IdpUpdateKnownRequest(
        Auth0.MyOrganizationApi.IdpWaadUpdateRequest value
    ) => new("idpWaadUpdateRequest", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<IdpUpdateKnownRequest>
    {
        public override IdpUpdateKnownRequest? Read(
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
                    ("idpAdfsUpdateRequest", typeof(Auth0.MyOrganizationApi.IdpAdfsUpdateRequest)),
                    (
                        "idpGoogleAppsUpdateRequest",
                        typeof(Auth0.MyOrganizationApi.IdpGoogleAppsUpdateRequest)
                    ),
                    ("idpOidcUpdateRequest", typeof(Auth0.MyOrganizationApi.IdpOidcUpdateRequest)),
                    ("idpOktaUpdateRequest", typeof(Auth0.MyOrganizationApi.IdpOktaUpdateRequest)),
                    (
                        "idpPingFederateUpdateRequest",
                        typeof(Auth0.MyOrganizationApi.IdpPingFederateUpdateRequest)
                    ),
                    (
                        "idpSamlpUpdateRequest",
                        typeof(Auth0.MyOrganizationApi.IdpSamlpUpdateRequest)
                    ),
                    ("idpWaadUpdateRequest", typeof(Auth0.MyOrganizationApi.IdpWaadUpdateRequest)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            IdpUpdateKnownRequest result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into IdpUpdateKnownRequest"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            IdpUpdateKnownRequest value,
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

        public override IdpUpdateKnownRequest ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            IdpUpdateKnownRequest result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            IdpUpdateKnownRequest value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
