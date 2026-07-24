# Testing

- **Framework:** NUnit 4.5.1 with NUnit3TestAdapter 6.2.0 and NUnit.Analyzers 4.14.0.
- **HTTP mocking:** WireMock.Net 2.11.0 — an in-process mock server, so endpoint tests contact **no** live Auth0 tenant.
- **Coverage:** coverlet.collector 10.0.1 → Cobertura XML → uploaded to Codecov in CI. No enforced local threshold.
- **Test project target:** `net9.0` only (the SDK itself multi-targets; tests do not).

## Layout

| Directory | What it covers |
|-----------|----------------|
| `Unit/MockServer/` | Per-endpoint tests mirroring the client tree (`Organization/Domains/GetTest.cs`, etc.), driven by WireMock |
| `Unit/Wrapper/` | Hand-written wrapper tests (token providers, `MyOrganizationClient`) — fernignored |
| `Core/` | Runtime tests: JSON (dates, additional properties), pagination, retries, query-string building |
| `Utils/` | Assertion helpers (`JsonAssert`, comparers) |

## Conventions

- Fixtures use `[TestFixture]` and `[Parallelizable(ParallelScope.Self)]`; tests are `[NUnit.Framework.Test] public async Task ...`.
- MockServer tests follow: build a `mockResponse` string → `Server.Given(Request.Create().WithPath(...).UsingGet()).RespondWith(...)` → call the client → assert with `JsonAssert.AreEqual(response, mockResponse)`.
- `BaseMockServerTest` provides the `Server` (WireMock) and a preconfigured `Client`.

## Running

```bash
# All unit tests
dotnet test src/Auth0.MyOrganizationApi.Test/Auth0.MyOrganizationApi.Test.csproj

# Single class
dotnet test src/Auth0.MyOrganizationApi.Test/Auth0.MyOrganizationApi.Test.csproj --filter "FullyQualifiedName~CreateTest"
```

No live/integration/acceptance tier exists in this repo — every test is offline and credential-free.
