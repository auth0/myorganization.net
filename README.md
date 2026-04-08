![C# SDK for Auth0 MyOrganization](https://cdn.auth0.com/website/sdks/banners/myorganization-csharp-banner.png)

<div align="center">

[![NuGet](https://img.shields.io/nuget/v/Auth0.MyOrganizationApi?style=flat-square)](https://nuget.org/packages/Auth0.MyOrganizationApi)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Auth0.MyOrganizationApi?style=flat-square)](https://nuget.org/packages/Auth0.MyOrganizationApi)
[![Build Status](https://img.shields.io/github/actions/workflow/status/atko-cic/myorganization.net/ci.yml?branch=main&style=flat-square)](https://github.com/atko-cic/myorganization.net/actions?query=branch%3Amain)
[![License](https://img.shields.io/github/license/atko-cic/myorganization.net.svg?style=flat-square)](https://github.com/atko-cic/myorganization.net/blob/main/LICENSE)

📚 [Documentation](#documentation) • 🚀 [Getting Started](#getting-started) • 💬 [Feedback](#feedback)

</div>

---

## Documentation

- [Docs site](https://www.auth0.com/docs) — explore our docs site and learn more about Auth0.
- [API Reference](./reference.md) - Complete API reference documentation.

## Getting Started

### Requirements

This library supports the following targets:

- .NET 8.0+
- .NET Standard 2.0+
- .NET Framework 4.6.2+

### Installation

The SDK is available on [NuGet](https://www.nuget.org/packages/Auth0.MyOrganizationApi) and can be installed via the CLI or Package Manager Console:

```sh
dotnet add package Auth0.MyOrganizationApi
```

### Usage

#### Client Credentials (M2M)

Use `ClientCredentialsTokenProvider.WithClientSecret` for machine-to-machine authentication via the OAuth2 client credentials grant. The SDK automatically fetches, caches, and refreshes access tokens.

```csharp
using Auth0.MyOrganizationApi;
using Auth0.MyOrganizationApi.Organization;

var client = new MyOrganizationClient(new MyOrganizationClientOptions
{
    Domain = "<YOUR_AUTH0_DOMAIN>",  // e.g. "mytenant.auth0.com"
    TokenProvider = ClientCredentialsTokenProvider
        .WithClientSecret(
            "<YOUR_AUTH0_DOMAIN>",
            "<YOUR_CLIENT_ID>",
            "<YOUR_CLIENT_SECRET>"
        )
        .Build()
});

var details = await client.OrganizationDetails.GetAsync();
Console.WriteLine(details);
```

> **Note**
> The domain must not include a scheme prefix or any path/trailing slash  — use `"mytenant.auth0.com"`, not `"https://mytenant.auth0.com"` or `"mytenant.auth0.com/"`. An `ArgumentException` is thrown if an invalid domain value is detected.

> **Important**
> The example above assumes a [Default Organization](https://auth0.com/docs/manage-users/organizations/organizations-for-m2m-applications/configure-your-application-for-m2m-access#set-default-organization-for-an-application) is configured for your tenant. If no default organization is set, you will receive the error `An organization is required`. In that case, chain `.WithOrganization()` with the ID or name of an existing organization (the example below uses an ID)

```csharp
var client = new MyOrganizationClient(new MyOrganizationClientOptions
{
    Domain = "<YOUR_AUTH0_DOMAIN>",
    TokenProvider = ClientCredentialsTokenProvider
        .WithClientSecret(
            "<YOUR_AUTH0_DOMAIN>",
            "<YOUR_CLIENT_ID>",
            "<YOUR_CLIENT_SECRET>"
        )
        .WithOrganization("org_<YOUR_ORG_ID>")
        .Build()
});
```

> **Note**
> The default audience is `https://{domain}/my-org/`. To specify a custom audience, chain `.WithAudience()` on the builder:

```csharp
var client = new MyOrganizationClient(new MyOrganizationClientOptions
{
    Domain = "<YOUR_AUTH0_DOMAIN>",
    TokenProvider = ClientCredentialsTokenProvider
        .WithClientSecret(
            "<YOUR_AUTH0_DOMAIN>",
            "<YOUR_CLIENT_ID>",
            "<YOUR_CLIENT_SECRET>"
        )
        .WithAudience("https://custom-api.example.com/")
        .Build()
});
```

#### Private Key JWT

Use `ClientCredentialsTokenProvider.WithClientAssertion` for authentication using a signed JWT assertion instead of a client secret. The SDK creates a JWT signed with your private key, then exchanges it for an access token via the `client_credentials` grant with `client_assertion`.

Supported signing algorithms: RS256, HS256

```csharp
using System.Security.Cryptography;
using Auth0.MyOrganizationApi;
using Microsoft.IdentityModel.Tokens;

var rsa = RSA.Create();
rsa.ImportFromPem(File.ReadAllText("private_key.pem"));
var securityKey = new RsaSecurityKey(rsa);

var client = new MyOrganizationClient(new MyOrganizationClientOptions
{
    Domain = "<YOUR_AUTH0_DOMAIN>",
    TokenProvider = ClientCredentialsTokenProvider
        .WithClientAssertion(
            "<YOUR_AUTH0_DOMAIN>",
            "<YOUR_CLIENT_ID>",
            securityKey,
            "RS256"
        )
        .Build()
});
```

> **Note**
> The default audience is `https://{domain}/my-org/`. To specify a custom audience, chain `.WithAudience()` on the builder:

```csharp
var client = new MyOrganizationClient(new MyOrganizationClientOptions
{
    Domain = "<YOUR_AUTH0_DOMAIN>",
    TokenProvider = ClientCredentialsTokenProvider
        .WithClientAssertion(
            "<YOUR_AUTH0_DOMAIN>",
            "<YOUR_CLIENT_ID>",
            securityKey,
            "RS256"
        )
        .WithAudience("https://custom-api.example.com/")
        .Build()
});
```

#### Custom Token Source

Use `DelegateTokenProvider` to provide your own token retrieval logic. This gives you full control over how access tokens are obtained, cached, and refreshed.

```csharp
using Auth0.MyOrganizationApi;

var client = new MyOrganizationClient(new MyOrganizationClientOptions
{
    Domain = "<YOUR_AUTH0_DOMAIN>",
    TokenProvider = new DelegateTokenProvider(async cancellationToken =>
    {
        // Your custom logic to obtain a token
        return await GetTokenFromExternalSourceAsync(cancellationToken);
    })
});
```

#### Static Token

If you already have a bearer token, the recommended approach is to use `MyOrganizationClient` with a `DelegateTokenProvider`. This keeps token management consistent and gives you access to all wrapper features such as retries and timeouts:

```csharp
using Auth0.MyOrganizationApi;

var client = new MyOrganizationClient(new MyOrganizationClientOptions
{
    Domain = "<YOUR_AUTH0_DOMAIN>",
    TokenProvider = new DelegateTokenProvider(_ => Task.FromResult("<YOUR_API_TOKEN>"))
});
```

Alternatively, you can use `MyOrganizationApiClient` directly. This is the underlying generated client and accepts a static token without any token lifecycle management — the token will not be refreshed automatically. This approach is only recommended for advanced scenarios such as test harnesses, middleware, or environments that inject tokens externally:

```csharp
using Auth0.MyOrganizationApi;

var client = new MyOrganizationApiClient(
    token: "<YOUR_API_TOKEN>",
    clientOptions: new ClientOptions
    {
        BaseUrl = "https://<YOUR_AUTH0_DOMAIN>/my-org"
    }
);
```

### Pagination

List endpoints that support pagination return a cursor-based response. Each response includes a `Next` property — when non-null, pass its value as the `next` query parameter to retrieve the next page.

```csharp
using Auth0.MyOrganizationApi;
using Auth0.MyOrganizationApi.Organization;

// Fetch the first page.
var response = await client.Organization.Domains.ListAsync();

foreach (var domain in response.OrganizationDomains)
{
    Console.WriteLine(domain.Domain);
}

// Fetch subsequent pages using the cursor.
while (response.Next != null)
{
    response = await client.Organization.Domains.ListAsync(
        new RequestOptions
        {
            AdditionalQueryParameters = new Dictionary<string, string>
            {
                { "next", response.Next }
            }
        }
    );

    foreach (var domain in response.OrganizationDomains)
    {
        Console.WriteLine(domain.Domain);
    }
}
```

### Request Options

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
        MaxRetries = 5,                  // More retries for this call
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
| `Domain` | Auth0 tenant domain (e.g. `"mytenant.auth0.com"`); used to construct the base URL as `https://{Domain}/my-org` |
| `BaseUrl` | Override the base URL directly; takes precedence over `Domain` |
| `HttpClient` | Provide a custom `HttpClient` |
| `AdditionalHeaders` | Set additional HTTP headers |
| `MaxRetries` | Set max retry attempts |
| `Timeout` | Set request timeout |
| `AdditionalQueryParameters` | Add query parameters |
| `AdditionalBodyProperties` | Add extra JSON body properties |

### Raw Responses

Access raw HTTP response data (status code, headers, URL) alongside parsed response data using the `.WithRawResponse()` method:

```csharp
using Auth0.MyOrganizationApi;

var result = await client.Organization.Domains.ListAsync().WithRawResponse();

// Access the parsed data.
foreach (var domain in result.Data.OrganizationDomains)
{
    Console.WriteLine(domain.Domain);
}

// Access raw response metadata.
Console.WriteLine($"Status: {(int)result.RawResponse.StatusCode}");
Console.WriteLine($"URL: {result.RawResponse.Url}");

// Access specific headers (case-insensitive).
if (result.RawResponse.Headers.TryGetValue("X-RateLimit-Remaining", out var remaining))
{
    Console.WriteLine($"Rate limit remaining: {remaining}");
}
```

### Error Handling

API calls that return non-success status codes throw typed exceptions. These can be caught using standard C# exception handling:

```csharp
using Auth0.MyOrganizationApi;

try
{
    var response = await client.Organization.Domains.CreateAsync(request);
}
catch (NotFoundError e)
{
    Console.WriteLine(e.Body);
    Console.WriteLine(e.StatusCode);
}
catch (UnauthorizedError e)
{
    Console.WriteLine(e.Body);
}
catch (MyOrganizationApiException e)
{
    // Catch any other API error.
    Console.WriteLine($"Status: {e.StatusCode}");
    Console.WriteLine(e.Body);
}
```

Available error types:

| Type | Status Code | Description |
|---|---|---|
| `BadRequestError` | 400 | Invalid request body |
| `UnauthorizedError` | 401 | Token missing, invalid, or expired |
| `ForbiddenError` | 403 | Insufficient scope |
| `NotFoundError` | 404 | Resource not found |
| `ConflictError` | 409 | Resource already exists |
| `TooManyRequestsError` | 429 | Rate limit exceeded |

### Explicit Null Values

By default, fields with `null` values are omitted from the JSON payload. To explicitly send `null` for a field, use `Optional<T?>` with `Optional<T?>.Of(null)`:

```csharp
using Auth0.MyOrganizationApi;
using Auth0.MyOrganizationApi.Core;

var branding = new OrgBranding();

// This sends {"logo_url": null} instead of omitting the field entirely.
branding.LogoUrl = Optional<string?>.Of(null);

// This sends {"logo_url": "https://example.com/logo.png"}.
branding.LogoUrl = Optional<string?>.Of("https://example.com/logo.png");

// Or use the implicit conversion — assigning a value directly also works.
branding.LogoUrl = "https://example.com/logo.png";

await client.OrganizationDetails.UpdateAsync(new OrgDetails { Branding = branding });
```

### Forward Compatible Enums

This SDK uses forward-compatible enums that can handle unknown values gracefully:

```csharp
using Auth0.MyOrganizationApi;

// Using a built-in value.
var oauthScope = OauthScope.ReadMyOrgConfiguration;

// Using a custom value.
var customScope = OauthScope.FromCustom("custom-value");

// Using in a switch statement.
switch (oauthScope.Value)
{
    case OauthScope.Values.ReadMyOrgConfiguration:
        Console.WriteLine("ReadMyOrgConfiguration");
        break;
    default:
        Console.WriteLine($"Unknown value: {oauthScope.Value}");
        break;
}

// Explicit casting.
string scopeString = (string)OauthScope.ReadMyOrgConfiguration;
OauthScope scopeFromString = (OauthScope)"read:my_org:configuration";
```

### Retries

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

### Timeouts

The SDK defaults to a 30 second timeout. Configure via the `Timeout` option:

```csharp
var client = new MyOrganizationClient(new MyOrganizationClientOptions
{
    TokenProvider = tokenProvider,
    Timeout = TimeSpan.FromSeconds(10)
});
```

### Base URL

The base URL defaults to `https://{domain}/my-org` when `Domain` is set.

> **Note**
> Use `BaseUrl` only in cases where the constructed URL does not match your environment, such as when using custom domains or a domain per organization.

```csharp
using Auth0.MyOrganizationApi;

var client = new MyOrganizationClient(new MyOrganizationClientOptions
{
    BaseUrl = "https://custom.example.com/my-org",
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

### Telemetry

The SDK sends an `Auth0-Client` header on every request containing the SDK name (`Auth0.Net`), version, and .NET runtime target (base64-encoded JSON). The header is injected automatically and requires no configuration.

## Feedback

### Contributing

We appreciate feedback and contribution to this repo! Before you get started, please see the following:

- [Auth0's General Contribution Guidelines](https://github.com/auth0/open-source-template/blob/master/GENERAL-CONTRIBUTING.md)
- [Auth0's Code of Conduct Guidelines](https://github.com/auth0/open-source-template/blob/master/CODE-OF-CONDUCT.md)

While we value open-source contributions to this SDK, this library is generated programmatically. Additions made directly to this library would have to be moved over to our generation code, otherwise they would be overwritten upon the next generated release. Feel free to open a PR as a proof of concept, but know that we will not be able to merge it as-is. We suggest opening an issue first to discuss with us!

### Raise an Issue

To provide feedback or report a bug, please [raise an issue on our issue tracker](https://github.com/atko-cic/myorganization.net/issues).

### Vulnerability Reporting

Please do not report security vulnerabilities on the public GitHub issue tracker. The [Responsible Disclosure Program](https://auth0.com/responsible-disclosure-policy) details the procedure for disclosing security issues.

---

<p align="center">
  <picture>
    <source media="(prefers-color-scheme: light)" srcset="https://cdn.auth0.com/website/sdks/logos/auth0_light_mode.png" width="150">
    <source media="(prefers-color-scheme: dark)" srcset="https://cdn.auth0.com/website/sdks/logos/auth0_dark_mode.png" width="150">
    <img alt="Auth0 Logo" src="https://cdn.auth0.com/website/sdks/logos/auth0_light_mode.png" width="150">
  </picture>
</p>

<p align="center">Auth0 is an easy to implement, adaptable authentication and authorization platform.<br />To learn more check out <a href="https://auth0.com/why-auth0">Why Auth0?</a></p>

<p align="center">Copyright 2026 Okta, Inc. <br>
Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. <br> You may obtain a copy of the License at <a href="http://www.apache.org/licenses/LICENSE-2.0"> http://www.apache.org/licenses/LICENSE-2.0</a></p>
