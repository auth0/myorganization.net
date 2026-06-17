# Getting Started

This guide will help you get started with the Auth0 MyOrganization .NET SDK.

## Prerequisites

- An Auth0 account ([sign up for free](https://auth0.com/signup))
- A Machine-to-Machine application authorized for the MyOrganization API
- One of the following supported targets:
  - .NET 8.0+
  - .NET Standard 2.0+
  - .NET Framework 4.6.2+

## Installation

The SDK is available on [NuGet](https://www.nuget.org/packages/Auth0.MyOrganizationApi) and can be installed via the CLI or Package Manager Console:

```sh
dotnet add package Auth0.MyOrganizationApi
```

## Your First Request

Create a `MyOrganizationClient` with a token provider, then call an endpoint:

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

> [!NOTE]
> The domain must not include a scheme prefix or any path/trailing slash — use `"mytenant.auth0.com"`, not `"https://mytenant.auth0.com"` or `"mytenant.auth0.com/"`. An `ArgumentException` is thrown if an invalid domain value is detected.

> [!IMPORTANT]
> The example above assumes a [Default Organization](https://auth0.com/docs/manage-users/organizations/organizations-for-m2m-applications/configure-your-application-for-m2m-access#set-default-organization-for-an-application) is configured for your tenant. If no default organization is set, you will receive the error `An organization is required`. In that case, chain `.WithOrganization()` with the ID or name of an existing organization:

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

## Exploring the Client

The client exposes the MyOrganization API through strongly-typed sub-clients:

```csharp
// Organization-level details.
var details = await client.OrganizationDetails.GetAsync();

// Organization resources.
var domains = await client.Organization.Domains.ListAsync();
var roles = await client.Organization.Roles.ListAsync();
var members = await client.Organization.Members.ListAsync();
```

Available sub-clients include `OrganizationDetails` and `Organization` (with `Domains`, `Configuration`, `IdentityProviders`, `Roles`, `Memberships`, `Members`, and `Invitations`).

## Next Steps

- [Authentication](authentication.md) - Learn about the available token providers
- [Configuration](configuration.md) - Configure retries, timeouts, headers, and the base URL
- [Pagination & Error Handling](pagination-and-errors.md) - Page through lists and handle errors
- [API Reference](../api/Auth0.MyOrganizationApi.yml) - Complete API documentation
