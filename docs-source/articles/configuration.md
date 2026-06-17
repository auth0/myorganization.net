# Configuration

This guide covers the request and client configuration options available in the SDK.

## Request Options

Options can be configured at the client level (affecting all requests) or per-request:

```csharp
// Client-level options (applied to every request).
var client = new MyOrganizationClient(new MyOrganizationClientOptions
{
    TokenProvider = tokenProvider,
    MaxRetries = 3,
    Timeout = TimeSpan.FromSeconds(10),
    AdditionalHeaders = new Dictionary<string, string?>
    {
        { "X-Custom-Header", "custom-value" }
    }
});

// Per-request overrides.
var response = await client.Organization.Domains.CreateAsync(
    request,
    new RequestOptions
    {
        MaxRetries = 5,                  // More retries for this call.
        Timeout = TimeSpan.FromSeconds(3),
        AdditionalHeaders = new Dictionary<string, string?>
        {
            { "X-Request-Id", "abc-123" }
        }
    }
);
```

Available options:

| Option | Description |
|---|---|
| `Domain` | Auth0 tenant domain (e.g. `"mytenant.auth0.com"`); used to construct the base URL as `https://{Domain}/my-org/v1` |
| `BaseUrl` | Override the base URL directly; takes precedence over `Domain` |
| `HttpClient` | Provide a custom `HttpClient` |
| `AdditionalHeaders` | Set additional HTTP headers |
| `MaxRetries` | Set max retry attempts |
| `Timeout` | Set request timeout |
| `AdditionalQueryParameters` | Add query parameters |
| `AdditionalBodyProperties` | Add extra JSON body properties |

## Retries

The SDK automatically retries requests with exponential backoff on the following status codes:

- `408` (Timeout)
- `429` (Too Many Requests)
- `5XX` (Internal Server Errors)

The default retry limit is 2 attempts. The `Retry-After` and `X-RateLimit-Reset` response headers are respected when present. Configure via the `MaxRetries` option:

```csharp
var client = new MyOrganizationClient(new MyOrganizationClientOptions
{
    TokenProvider = tokenProvider,
    MaxRetries = 5
});
```

## Timeouts

The SDK defaults to a 30 second timeout. Configure via the `Timeout` option:

```csharp
var client = new MyOrganizationClient(new MyOrganizationClientOptions
{
    TokenProvider = tokenProvider,
    Timeout = TimeSpan.FromSeconds(10)
});
```

## Base URL

The base URL defaults to `https://{domain}/my-org/v1` when `Domain` is set.

> [!NOTE]
> Use `BaseUrl` only in cases where the constructed URL does not match your environment, such as when using custom domains or a domain per organization.

```csharp
using Auth0.MyOrganizationApi;

var client = new MyOrganizationClient(new MyOrganizationClientOptions
{
    BaseUrl = "https://custom.example.com/my-org/v1",
    TokenProvider = ClientCredentialsTokenProvider
        .WithClientSecret(
            "<YOUR_AUTH0_DOMAIN>",
            "<YOUR_CLIENT_ID>",
            "<YOUR_CLIENT_SECRET>"
        )
        .WithAudience("https://custom.example.com/my-org")
        .Build()
});
```

## Telemetry

The SDK sends an `Auth0-Client` header on every request containing the SDK name (`MyOrganization.NET`), version, and .NET runtime target (base64-encoded JSON). The header is injected automatically and requires no configuration.

## Next Steps

- [Pagination & Error Handling](pagination-and-errors.md) - Page through lists and handle errors
- [API Reference](../api/Auth0.MyOrganizationApi.yml) - Complete API documentation
