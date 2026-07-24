# Code Style

Enforced by `.editorconfig` (ReSharper/Roslyn analyzer severities) and NUnit.Analyzers. Nullable reference types and implicit usings are enabled project-wide; `LangVersion` is 12.

## Naming

- Types, methods, public properties: `PascalCase`.
- Private fields: `_camelCase`.
- Async methods: suffixed `Async`.
- `Types/` and `Core/Public/` are exempt from the namespace-matches-folder check (see `.editorconfig`).

## Models (generated)

Generated models are `record` types using `System.Text.Json` attributes.

**✅ Good** — matches the generated pattern:

```csharp
[Serializable]
public record Role : IJsonOnDeserialized
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [Optional]
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    public override string ToString() => JsonUtils.Serialize(this);
}
```

**❌ Bad** — plain class, no JSON attributes, no `required`, PascalCase wire names:

```csharp
public class Role
{
    public string Id;              // field, not property; no [JsonPropertyName]
    public string Description;     // not marked optional; wire name won't match "description"
}
```

## Error hierarchy

- `MyOrganizationException` (base, extends `Exception`).
- `MyOrganizationApiException(message, statusCode, body)` — thrown for any non-2XX response.
- Concrete subtypes carry a typed `Body` and a fixed status code: `BadRequestError` (400), `UnauthorizedError` (401), `ForbiddenError` (403), `NotFoundError` (404), `ConflictError` (409), `TooManyRequestsError` (429).

Catch the specific type when you care about a status; catch `MyOrganizationApiException` as the fallback.

## Dominant patterns

- **Builder** — `ClientCredentialsTokenProvider.WithClientSecret(...).WithOrganization(...).WithAudience(...).Build()`.
- **Provider / Strategy** — `ITokenProvider` abstracts token acquisition (`ClientCredentialsTokenProvider`, `DelegateTokenProvider`).
- **Forward-compatible enums** — `readonly record struct` implementing `IStringEnum` with a `FromCustom(...)` escape hatch (e.g. `OauthScope`).
- **`Optional<T>`** — distinguishes "omit field" from "send explicit null" in JSON payloads.
