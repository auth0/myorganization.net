// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

[JsonConverter(typeof(IdpAdfsOptionsResponse.JsonConverter))]
[Serializable]
public class IdpAdfsOptionsResponse
{
    private IdpAdfsOptionsResponse(string type, object? value)
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
    /// Factory method to create a union from a Auth0.MyOrganizationApi.IdpAdfsOptionsResponseAdfsServer value.
    /// </summary>
    public static IdpAdfsOptionsResponse FromIdpAdfsOptionsResponseAdfsServer(
        Auth0.MyOrganizationApi.IdpAdfsOptionsResponseAdfsServer value
    ) => new("idpAdfsOptionsResponseAdfsServer", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.MyOrganizationApi.FedMetadataXml value.
    /// </summary>
    public static IdpAdfsOptionsResponse FromFedMetadataXml(
        Auth0.MyOrganizationApi.FedMetadataXml value
    ) => new("fedMetadataXml", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "idpAdfsOptionsResponseAdfsServer"
    /// </summary>
    public bool IsIdpAdfsOptionsResponseAdfsServer() => Type == "idpAdfsOptionsResponseAdfsServer";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "fedMetadataXml"
    /// </summary>
    public bool IsFedMetadataXml() => Type == "fedMetadataXml";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.MyOrganizationApi.IdpAdfsOptionsResponseAdfsServer"/> if <see cref="Type"/> is 'idpAdfsOptionsResponseAdfsServer', otherwise throws an exception.
    /// </summary>
    /// <exception cref="MyOrganizationException">Thrown when <see cref="Type"/> is not 'idpAdfsOptionsResponseAdfsServer'.</exception>
    public Auth0.MyOrganizationApi.IdpAdfsOptionsResponseAdfsServer AsIdpAdfsOptionsResponseAdfsServer() =>
        IsIdpAdfsOptionsResponseAdfsServer()
            ? (Auth0.MyOrganizationApi.IdpAdfsOptionsResponseAdfsServer)Value!
            : throw new MyOrganizationException(
                "Union type is not 'idpAdfsOptionsResponseAdfsServer'"
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
    /// Attempts to cast the value to a <see cref="Auth0.MyOrganizationApi.IdpAdfsOptionsResponseAdfsServer"/> and returns true if successful.
    /// </summary>
    public bool TryGetIdpAdfsOptionsResponseAdfsServer(
        out Auth0.MyOrganizationApi.IdpAdfsOptionsResponseAdfsServer? value
    )
    {
        if (Type == "idpAdfsOptionsResponseAdfsServer")
        {
            value = (Auth0.MyOrganizationApi.IdpAdfsOptionsResponseAdfsServer)Value!;
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
            Auth0.MyOrganizationApi.IdpAdfsOptionsResponseAdfsServer,
            T
        > onIdpAdfsOptionsResponseAdfsServer,
        Func<Auth0.MyOrganizationApi.FedMetadataXml, T> onFedMetadataXml
    )
    {
        return Type switch
        {
            "idpAdfsOptionsResponseAdfsServer" => onIdpAdfsOptionsResponseAdfsServer(
                AsIdpAdfsOptionsResponseAdfsServer()
            ),
            "fedMetadataXml" => onFedMetadataXml(AsFedMetadataXml()),
            _ => throw new MyOrganizationException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        Action<Auth0.MyOrganizationApi.IdpAdfsOptionsResponseAdfsServer> onIdpAdfsOptionsResponseAdfsServer,
        Action<Auth0.MyOrganizationApi.FedMetadataXml> onFedMetadataXml
    )
    {
        switch (Type)
        {
            case "idpAdfsOptionsResponseAdfsServer":
                onIdpAdfsOptionsResponseAdfsServer(AsIdpAdfsOptionsResponseAdfsServer());
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
        if (obj is not IdpAdfsOptionsResponse other)
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

    public static implicit operator IdpAdfsOptionsResponse(
        Auth0.MyOrganizationApi.IdpAdfsOptionsResponseAdfsServer value
    ) => new("idpAdfsOptionsResponseAdfsServer", value);

    public static implicit operator IdpAdfsOptionsResponse(
        Auth0.MyOrganizationApi.FedMetadataXml value
    ) => new("fedMetadataXml", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<IdpAdfsOptionsResponse>
    {
        public override IdpAdfsOptionsResponse? Read(
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
                        "idpAdfsOptionsResponseAdfsServer",
                        typeof(Auth0.MyOrganizationApi.IdpAdfsOptionsResponseAdfsServer)
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
                            IdpAdfsOptionsResponse result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into IdpAdfsOptionsResponse"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            IdpAdfsOptionsResponse value,
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

        public override IdpAdfsOptionsResponse ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            IdpAdfsOptionsResponse result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            IdpAdfsOptionsResponse value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
