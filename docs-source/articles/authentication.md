# Authentication

The SDK obtains access tokens through a `TokenProvider`. Choose the provider that matches how your application authenticates with Auth0. In every case, the SDK injects the token as a bearer credential on each request.

## Client Credentials (M2M)

Use `ClientCredentialsTokenProvider.WithClientSecret` for machine-to-machine authentication via the OAuth2 client credentials grant. The SDK automatically fetches, caches, and refreshes access tokens.

```csharp
using Auth0.MyOrganizationApi;

var client = new MyOrganizationClient(new MyOrganizationClientOptions
{
    Domain = "<YOUR_AUTH0_DOMAIN>",
    TokenProvider = ClientCredentialsTokenProvider
        .WithClientSecret(
            "<YOUR_AUTH0_DOMAIN>",
            "<YOUR_CLIENT_ID>",
            "<YOUR_CLIENT_SECRET>"
        )
        .Build()
});
```

### Specifying an Organization

If no [Default Organization](https://auth0.com/docs/manage-users/organizations/organizations-for-m2m-applications/configure-your-application-for-m2m-access#set-default-organization-for-an-application) is configured, chain `.WithOrganization()` with an organization ID or name:

```csharp
TokenProvider = ClientCredentialsTokenProvider
    .WithClientSecret("<YOUR_AUTH0_DOMAIN>", "<YOUR_CLIENT_ID>", "<YOUR_CLIENT_SECRET>")
    .WithOrganization("org_<YOUR_ORG_ID>")
    .Build()
```

### Custom Audience

The default audience is `https://{domain}/my-org/`. To specify a custom audience, chain `.WithAudience()`:

```csharp
TokenProvider = ClientCredentialsTokenProvider
    .WithClientSecret("<YOUR_AUTH0_DOMAIN>", "<YOUR_CLIENT_ID>", "<YOUR_CLIENT_SECRET>")
    .WithAudience("https://custom-api.example.com/")
    .Build()
```

## Private Key JWT

Use `ClientCredentialsTokenProvider.WithClientAssertion` for authentication using a signed JWT assertion instead of a client secret. The SDK creates a JWT signed with your private key, then exchanges it for an access token via the `client_credentials` grant with `client_assertion`.

Supported signing algorithms: **RS256**, **HS256**.

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

`.WithOrganization()` and `.WithAudience()` can be chained here as well.

## Custom Token Source

Use `DelegateTokenProvider` to provide your own token retrieval logic. This gives you full control over how access tokens are obtained, cached, and refreshed.

```csharp
using Auth0.MyOrganizationApi;

var client = new MyOrganizationClient(new MyOrganizationClientOptions
{
    Domain = "<YOUR_AUTH0_DOMAIN>",
    TokenProvider = new DelegateTokenProvider(async cancellationToken =>
    {
        // Your custom logic to obtain a token.
        return await GetTokenFromExternalSourceAsync(cancellationToken);
    })
});
```

## Static Token

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
        BaseUrl = "https://<YOUR_AUTH0_DOMAIN>/my-org/v1"
    }
);
```

## Next Steps

- [Configuration](configuration.md) - Configure retries, timeouts, headers, and the base URL
- [Pagination & Error Handling](pagination-and-errors.md) - Page through lists and handle errors
