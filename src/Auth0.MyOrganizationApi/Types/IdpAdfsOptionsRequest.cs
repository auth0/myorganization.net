// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.MyOrganizationApi.Core;

namespace Auth0.MyOrganizationApi;

[JsonConverter(typeof(IdpAdfsOptionsRequest.JsonConverter))]
[Serializable]
public class IdpAdfsOptionsRequest
{
    private IdpAdfsOptionsRequest(string type, object? value)
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
    /// Factory method to create a union from a Auth0.MyOrganizationApi.IdpAdfsOptionsRequestAdfsServer value.
    /// </summary>
    public static IdpAdfsOptionsRequest FromIdpAdfsOptionsRequestAdfsServer(
        Auth0.MyOrganizationApi.IdpAdfsOptionsRequestAdfsServer value
    ) => new("idpAdfsOptionsRequestAdfsServer", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.MyOrganizationApi.FedMetadataXml value.
    /// </summary>
    public static IdpAdfsOptionsRequest FromFedMetadataXml(
        Auth0.MyOrganizationApi.FedMetadataXml value
    ) => new("fedMetadataXml", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "idpAdfsOptionsRequestAdfsServer"
    /// </summary>
    public bool IsIdpAdfsOptionsRequestAdfsServer() => Type == "idpAdfsOptionsRequestAdfsServer";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "fedMetadataXml"
    /// </summary>
    public bool IsFedMetadataXml() => Type == "fedMetadataXml";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.MyOrganizationApi.IdpAdfsOptionsRequestAdfsServer"/> if <see cref="Type"/> is 'idpAdfsOptionsRequestAdfsServer', otherwise throws an exception.
    /// </summary>
    /// <exception cref="MyOrganizationException">Thrown when <see cref="Type"/> is not 'idpAdfsOptionsRequestAdfsServer'.</exception>
    public Auth0.MyOrganizationApi.IdpAdfsOptionsRequestAdfsServer AsIdpAdfsOptionsRequestAdfsServer() =>
        IsIdpAdfsOptionsRequestAdfsServer()
            ? (Auth0.MyOrganizationApi.IdpAdfsOptionsRequestAdfsServer)Value!
            : throw new MyOrganizationException(
                "Union type is not 'idpAdfsOptionsRequestAdfsServer'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.MyOrganizationApi.FedMetadataXml"/> if <see cref="Type"/> is 'fedMetadataXml', otherwise throws an exception.
    /// </summary>
    /// <exception cref="MyOrganizationException">Thrown when <see cref="Type"/> is not 'fedMetadataXml'.</exception>
    public Auth0.MyOrganizationApi.FedMetadataXml AsFedMetadataXml() =>
        IsFedMetadataXml()
            ? (Auth0.MyOrganizationApi.FedMetadataXml)Value!
            : throw new MyOrganizationException("Union type is not 'fedMetadataXml'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.MyOrganizationApi.IdpAdfsOptionsRequestAdfsServer"/> and returns true if successful.
    /// </summary>
    public bool TryGetIdpAdfsOptionsRequestAdfsServer(
        out Auth0.MyOrganizationApi.IdpAdfsOptionsRequestAdfsServer? value
    )
    {
        if (Type == "idpAdfsOptionsRequestAdfsServer")
        {
            value = (Auth0.MyOrganizationApi.IdpAdfsOptionsRequestAdfsServer)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.MyOrganizationApi.FedMetadataXml"/> and returns true if successful.
    /// </summary>
    public bool TryGetFedMetadataXml(out Auth0.MyOrganizationApi.FedMetadataXml? value)
    {
        if (Type == "fedMetadataXml")
        {
            value = (Auth0.MyOrganizationApi.FedMetadataXml)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.MyOrganizationApi.IdpAdfsOptionsRequestAdfsServer,
            T
        > onIdpAdfsOptionsRequestAdfsServer,
        Func<Auth0.MyOrganizationApi.FedMetadataXml, T> onFedMetadataXml
    )
    {
        return Type switch
        {
            "idpAdfsOptionsRequestAdfsServer" => onIdpAdfsOptionsRequestAdfsServer(
                AsIdpAdfsOptionsRequestAdfsServer()
            ),
            "fedMetadataXml" => onFedMetadataXml(AsFedMetadataXml()),
            _ => throw new MyOrganizationException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        Action<Auth0.MyOrganizationApi.IdpAdfsOptionsRequestAdfsServer> onIdpAdfsOptionsRequestAdfsServer,
        Action<Auth0.MyOrganizationApi.FedMetadataXml> onFedMetadataXml
    )
    {
        switch (Type)
        {
            case "idpAdfsOptionsRequestAdfsServer":
                onIdpAdfsOptionsRequestAdfsServer(AsIdpAdfsOptionsRequestAdfsServer());
                break;
            case "fedMetadataXml":
                onFedMetadataXml(AsFedMetadataXml());
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
        if (obj is not IdpAdfsOptionsRequest other)
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

    public static implicit operator IdpAdfsOptionsRequest(
        Auth0.MyOrganizationApi.IdpAdfsOptionsRequestAdfsServer value
    ) => new("idpAdfsOptionsRequestAdfsServer", value);

    public static implicit operator IdpAdfsOptionsRequest(
        Auth0.MyOrganizationApi.FedMetadataXml value
    ) => new("fedMetadataXml", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<IdpAdfsOptionsRequest>
    {
        public override IdpAdfsOptionsRequest? Read(
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
                    (
                        "idpAdfsOptionsRequestAdfsServer",
                        typeof(Auth0.MyOrganizationApi.IdpAdfsOptionsRequestAdfsServer)
                    ),
                    ("fedMetadataXml", typeof(Auth0.MyOrganizationApi.FedMetadataXml)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            IdpAdfsOptionsRequest result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into IdpAdfsOptionsRequest"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            IdpAdfsOptionsRequest value,
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

        public override IdpAdfsOptionsRequest ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            IdpAdfsOptionsRequest result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            IdpAdfsOptionsRequest value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
