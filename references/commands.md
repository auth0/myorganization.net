# Commands

Full command reference for Auth0.MyOrganizationApi. Commands mirror `.github/workflows/build.yml`.

## Build

```bash
# Restore dependencies
dotnet restore Auth0.MyOrganizationApi.sln

# Build (Release, as CI does)
dotnet build Auth0.MyOrganizationApi.sln --configuration Release --no-restore
```

## Test

```bash
# Run all unit tests
dotnet test src/Auth0.MyOrganizationApi.Test/Auth0.MyOrganizationApi.Test.csproj

# Run tests with coverage (exact CI invocation)
dotnet test src/Auth0.MyOrganizationApi.Test/Auth0.MyOrganizationApi.Test.csproj \
  --collect:"XPlat Code coverage" \
  --results-directory ./TestResults/ \
  /p:CollectCoverage=true \
  /p:CoverletOutputFormat=cobertura

# Run a single test class by name filter
dotnet test src/Auth0.MyOrganizationApi.Test/Auth0.MyOrganizationApi.Test.csproj \
  --filter "FullyQualifiedName~GetTest"
```

## Lint / Format

There is no dedicated lint CI step. Style is enforced via `.editorconfig` (ReSharper/Roslyn analyzer hints) and NUnit.Analyzers at build time. To apply formatting:

```bash
dotnet format Auth0.MyOrganizationApi.sln
```

## Clean

```bash
dotnet clean Auth0.MyOrganizationApi.sln
```

> CI uses .NET SDK `10.0.x` (see `build.yml`) to build all four target frameworks. Ensure a compatible SDK is installed locally.
