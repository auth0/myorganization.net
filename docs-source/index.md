![](https://cdn.auth0.com/website/sdks/banners/myorganization-net-banner.png)

[![NuGet Version](https://img.shields.io/nuget/v/Auth0.MyOrganizationApi?style=flat&logo=nuget)](https://www.nuget.org/packages/Auth0.MyOrganizationApi)
![Downloads](https://img.shields.io/nuget/dt/Auth0.MyOrganizationApi)
[![License](https://img.shields.io/:license-Apache%202.0-blue.svg?style=flat)](https://www.apache.org/licenses/LICENSE-2.0)

Welcome to the official documentation for the Auth0 MyOrganization .NET SDK.

This library provides a strongly-typed .NET client for the Auth0 MyOrganization API, with built-in token management, automatic retries, pagination helpers, and typed error handling.

## Features

- 🔐 **Flexible Authentication** - Client credentials (M2M), Private Key JWT, and custom token sources
- 🔁 **Automatic Token Management** - Tokens are fetched, cached, and refreshed for you
- 📄 **Cursor-Based Pagination** - Iterate through list endpoints with a simple cursor
- ⚙️ **Configurable Requests** - Per-client and per-request retries, timeouts, and headers
- 🎯 **Typed Error Handling** - Catch specific exceptions mapped to HTTP status codes
- 📦 **Broad Target Support** - .NET 8.0+, .NET Standard 2.0+, and .NET Framework 4.6.2+

## Quick Start

Install the NuGet package:

```sh
dotnet add package Auth0.MyOrganizationApi
```

Create a client and make your first call:

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

## Documentation Sections

### Getting Started
- [Getting Started](articles/getting-started.md) - Installation and your first request
- [Authentication](articles/authentication.md) - Token providers and authentication strategies
- [Configuration](articles/configuration.md) - Request options, retries, timeouts, and base URL
- [Pagination & Error Handling](articles/pagination-and-errors.md) - Paging, raw responses, errors, enums, and null values

### Reference
- [API Reference](api/Auth0.MyOrganizationApi.yml) - Complete API documentation

## Resources

- [GitHub Repository](https://github.com/auth0/myorganization.net)
- [Auth0 Documentation](https://auth0.com/docs)
- [Organizations for M2M Applications](https://auth0.com/docs/manage-users/organizations/organizations-for-m2m-applications)

## License

This project is licensed under the Apache License 2.0 - see the [LICENSE](https://github.com/auth0/myorganization.net/blob/main/LICENSE) file for details.
