# Change Log

## [1.0.0-beta.0](https://github.com/auth0/myorganization.net/tree/1.0.0-beta.0) (2026-04-09)

**Added**
- Regenerate SDK with latest API spec [\#15](https://github.com/auth0/myorganization.net/pull/15) ([kailash-b](https://github.com/kailash-b))
- Automates release with shiprc [\#14](https://github.com/auth0/myorganization.net/pull/14) ([kailash-b](https://github.com/kailash-b))
- Adds dependabot.yml and CODEOWNERS [\#4](https://github.com/auth0/myorganization.net/pull/4) ([kailash-b](https://github.com/kailash-b))
- `MyOrganizationClient` high-level wrapper with automatic token lifecycle management (`IDisposable`, manages internal `HttpClient`) [\#15](https://github.com/auth0/myorganization.net/pull/15) ([kailash-b](https://github.com/kailash-b))
- `ClientCredentialsTokenProvider` for OAuth 2.0 client credentials grant — supports client secret and private key JWT (RS256/HS256), with automatic token caching, expiry, and thread-safe refresh [\#15](https://github.com/auth0/myorganization.net/pull/15) ([kailash-b](https://github.com/kailash-b))
- `DelegateTokenProvider` for custom token sources (vaults, external services, static tokens) [\#15](https://github.com/auth0/myorganization.net/pull/15) ([kailash-b](https://github.com/kailash-b))
- `MyOrganizationApiClient` low-level generated client with static bearer token support [\#15](https://github.com/auth0/myorganization.net/pull/15) ([kailash-b](https://github.com/kailash-b))
- Organization Details API — get and update org display name and branding [\#15](https://github.com/auth0/myorganization.net/pull/15) ([kailash-b](https://github.com/kailash-b))
- Organization Domains API — list, create, get, delete, and verify custom domains [\#15](https://github.com/auth0/myorganization.net/pull/15) ([kailash-b](https://github.com/kailash-b))
- Organization Identity Providers API — create, get, list, update, delete, and detach IDPs (OIDC, SAML, ADFS, Google Apps); refresh attribute mappings [\#15](https://github.com/auth0/myorganization.net/pull/15) ([kailash-b](https://github.com/kailash-b))
- Provisioning API — create, get, delete provisioning configs; refresh provisioning attribute mappings [\#15](https://github.com/auth0/myorganization.net/pull/15) ([kailash-b](https://github.com/kailash-b))
- SCIM Tokens API — list, create, and revoke SCIM tokens per IDP [\#15](https://github.com/auth0/myorganization.net/pull/15) ([kailash-b](https://github.com/kailash-b))
- Configuration API — retrieve My Organization API configuration (connection deletion behavior, allowed strategies) [\#15](https://github.com/auth0/myorganization.net/pull/15) ([kailash-b](https://github.com/kailash-b))
- `Optional<T>` struct to distinguish "field not sent" from "field sent as null" in PATCH requests [\#15](https://github.com/auth0/myorganization.net/pull/15) ([kailash-b](https://github.com/kailash-b))
- Forward-compatible enums (`StringEnum<T>`) that gracefully handle unknown values from the API [\#15](https://github.com/auth0/myorganization.net/pull/15) ([kailash-b](https://github.com/kailash-b))
- Cursor-based pagination via `Pager<T>` and `BiPager<T>` with `IAsyncEnumerable<Page<T>>` support [\#15](https://github.com/auth0/myorganization.net/pull/15) ([kailash-b](https://github.com/kailash-b))
- Automatic retry with exponential backoff and jitter on `408`, `429`, and `5XX` responses; respects `Retry-After` and `X-RateLimit-Reset` headers [\#15](https://github.com/auth0/myorganization.net/pull/15) ([kailash-b](https://github.com/kailash-b))
- Per-request options (`RequestOptions`) to override timeout, retries, headers, base URL, and query/body parameters [\#15](https://github.com/auth0/myorganization.net/pull/15) ([kailash-b](https://github.com/kailash-b))
- `.WithRawResponse()` on all API calls to access HTTP status code, URL, and headers alongside parsed response data [\#15](https://github.com/auth0/myorganization.net/pull/15) ([kailash-b](https://github.com/kailash-b))
- Automatic `Auth0-Client` telemetry header (SDK name, version, .NET runtime target) on every request [\#15](https://github.com/auth0/myorganization.net/pull/15) ([kailash-b](https://github.com/kailash-b))
- Domain validation at client construction — rejects schemes and trailing slashes with `ArgumentException` [\#15](https://github.com/auth0/myorganization.net/pull/15) ([kailash-b](https://github.com/kailash-b))
- Typed exceptions for all HTTP error responses: `BadRequestError` (400), `UnauthorizedError` (401), `ForbiddenError` (403), `NotFoundError` (404), `ConflictError` (409), `TooManyRequestsError` (429) [\#15](https://github.com/auth0/myorganization.net/pull/15) ([kailash-b](https://github.com/kailash-b))
- Multi-framework support: .NET Framework 4.6.2, .NET Standard 2.0, .NET 8.0, .NET 9.0 [\#15](https://github.com/auth0/myorganization.net/pull/15) ([kailash-b](https://github.com/kailash-b))

**Security**
- chore: bump snyk/actions from 0.4.0 to 1.0.0 [\#5](https://github.com/auth0/myorganization.net/pull/5) ([dependabot[bot]](https://github.com/apps/dependabot))