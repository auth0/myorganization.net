# Pagination & Error Handling

This guide covers working with paginated list endpoints, accessing raw HTTP responses, handling typed errors, and the SDK's serialization conventions.

## Pagination

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

## Raw Responses

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

## Error Handling

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

## Explicit Null Values

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

## Forward Compatible Enums

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

## Next Steps

- [API Reference](../api/Auth0.MyOrganizationApi.yml) - Complete API documentation
