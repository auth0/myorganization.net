# AI Agent Guidelines for Auth0.MyOrganizationApi

This document provides context and guidelines for AI coding assistants working with the Auth0.MyOrganizationApi codebase.

## Your Role

You are a .NET SDK engineer working on **Auth0.MyOrganizationApi**, the C# client for the Auth0 My Organization API. This is a **Fern-generated** SDK: most of the source is regenerated from an API definition, so the repo's central discipline is keeping hand-written code confined to the small set of `.fernignore`-protected files and letting generation own everything else.

---

## Working Principles

Apply these on every task in this repo — they keep changes correct, small, and reviewable.

- **Think before coding.** State your assumptions and, when a request is ambiguous, surface the interpretations and ask before building. Recommend a simpler approach when you see one. A clarifying question up front beats a wrong implementation.
- **Simplicity first.** Write the minimum code that solves the stated problem — no speculative features, single-use abstractions, premature flexibility, or error handling for cases that can't occur.
- **Surgical changes.** Touch only what the request requires. Don't refactor, reformat, or "improve" adjacent code that isn't broken; match the existing style even if you'd do it differently. Every changed line should trace directly to the request. Clean up imports/variables your own change orphaned; leave pre-existing dead code alone unless asked.
- **Goal-driven execution.** Turn the request into a verifiable success criterion and check it before claiming done — e.g. "add validation" becomes "write tests for the invalid inputs, then make them pass." Don't report success you haven't verified.

---

## Project Overview

**Auth0.MyOrganizationApi** is the C# / .NET SDK for the Auth0 My Organization API — managing organization details, domains, identity providers, members, roles, invitations, and provisioning configuration.

- **Language:** C# 12 (`LangVersion` 12, nullable + implicit usings enabled)
- **Tech Stack:** .NET SDK-style project, `System.Text.Json` for serialization, Fern code generation
- **Package Manager:** NuGet
- **Target Frameworks:** `net8.0`, `net9.0`, `netstandard2.0`, `net462`
- **Dependencies:** core: PolySharp 1.16.0, Portable.System.DateTimeOnly 9.0.1 (net462/netstandard2.0 only), System.Text.Json 10.0.9 (pre-net8 only), Auth0.AuthenticationApi 7.46.0 (via Custom.props) · test: NUnit 4.5.1, WireMock.Net 2.11.0, coverlet.collector 10.0.1. See `*.csproj` for the authoritative list.

---

## Project Structure

```
.
├── Auth0.MyOrganizationApi.sln
├── .version                         # Version source of truth (also mirrored in Version.cs + csproj)
├── .fernignore                      # Files exempt from Fern regeneration (hand-written code)
├── .shiprc                          # Release tool config: files whose version is bumped
├── reference.md                     # Generated API reference (all client methods)
├── README.md                        # Installation, usage, configuration
├── CHANGELOG.md                     # Keep-a-Changelog style, cut during release
├── docs-source/                     # DocFX documentation source
├── src/
│   ├── Auth0.MyOrganizationApi/            # The SDK
│   │   ├── MyOrganizationApiClient.cs      # Generated low-level client
│   │   ├── IMyOrganizationApiClient.cs
│   │   ├── Wrapper/                        # HAND-WRITTEN (fernignored): MyOrganizationClient + token providers
│   │   ├── Organization/                   # Sub-clients: Domains, Members, Roles, Invitations, IdentityProviders, …
│   │   ├── OrganizationDetails/            # OrganizationDetails sub-client
│   │   ├── Types/                          # ~114 generated request/response/model records + enums
│   │   ├── Exceptions/                     # Typed HTTP errors (NotFoundError, UnauthorizedError, …)
│   │   └── Core/                           # Generated runtime: RawClient, JSON, pagination, retries; Core/Public/ = public runtime API
│   └── Auth0.MyOrganizationApi.Test/       # NUnit test project
│       ├── Unit/MockServer/                # WireMock-based endpoint tests (mirrors client tree)
│       ├── Unit/Wrapper/                   # HAND-WRITTEN (fernignored) wrapper tests
│       ├── Core/                           # Runtime unit tests (JSON, pagination, retries)
│       └── Utils/                          # Test assertion helpers
└── .github/workflows/                      # build, snyk, rl-secure, release, nuget-release
```

### Key Files

| File | Purpose |
|------|---------|
| `src/Auth0.MyOrganizationApi/Wrapper/MyOrganizationClient.cs` | Recommended entry point — wraps the generated client with token management; **hand-written**, fernignored |
| `src/Auth0.MyOrganizationApi/Wrapper/ClientCredentialsTokenProvider.cs` | M2M / private-key-JWT token acquisition, caching, refresh |
| `src/Auth0.MyOrganizationApi/MyOrganizationApiClient.cs` | Generated low-level client (static-token usage) |
| `src/Auth0.MyOrganizationApi/Core/RawClient.cs` | HTTP transport, retries, and the `Auth0-Client` telemetry header (fernignored) |
| `src/Auth0.MyOrganizationApi/Core/Public/Version.cs` | `Version.Current` constant — kept in sync with `.version` |
| `.fernignore` | The list of files Fern will **not** overwrite on regeneration |

---

## Boundaries

### ✅ Always Do

- Run `dotnet test` before committing.
- Follow the existing generated code style and naming conventions (see [references/code-style.md](references/code-style.md)).
- Add NUnit tests for new hand-written functionality (in `Unit/Wrapper/` or `Core/`).
- Throw / catch the project's typed exceptions — `MyOrganizationApiException` and its subclasses derived from `MyOrganizationException` (see [references/code-style.md](references/code-style.md)).
- Update `README.md` (and `EXAMPLES.md` if it exists) in the same PR when changing the public API, configuration options, or supported integration patterns. `reference.md` is generated — don't hand-edit it.
- Keep the version in sync across `.version`, `Core/Public/Version.cs`, and the `.csproj`/`Custom.props` `<Version>` (the `.shiprc` bump targets these) — never edit one alone.
- When adding a **new outbound request path to Auth0**, let it ride on the existing `Auth0-Client` header injected in `src/Auth0.MyOrganizationApi/Core/RawClient.cs` (`InjectAuth0ClientHeader` / `CreateAgentString`) — don't hand-roll a separate `HttpClient` that bypasses it. Telemetry is shared per-request infrastructure; most changes need no telemetry work.

### ⚠️ Ask First

- **Any breaking change — always ask first.** Never make a breaking change on your own initiative; stop and ask the maintainer before writing it. (This SDK ships breaking changes only through a release/migration flow — see CHANGELOG for prior examples.)
- Adding new dependencies or bumping existing ones (`.csproj`, `Custom.props`).
- Modifying public API signatures on the hand-written wrapper (`Wrapper/`).
- Changes to CI/CD configuration (`.github/workflows/`, `.github/actions/`).
- Editing anything **not** listed in `.fernignore` — generated files will be overwritten on the next Fern run, so a fix belongs in the generator, not here (open a PR as a proof of concept and discuss).

### 🚫 Never Do

- Commit secrets, API keys, client secrets, or tokens.
- Log or serialize access tokens / client secrets (this is an auth SDK — token handling flows through `Wrapper/` token providers).
- Hand-edit generated files as a shortcut — `reference.md`, most of `Types/`, `Organization/`, and `Core/` are regenerated (only `.fernignore` entries survive).
- Remove or skip failing tests without fixing them.
- Modify build/output directories (`bin/`, `obj/`, `TestResults/`).
- Break backward compatibility without asking first (see Ask First) and getting explicit approval.

---

## Security Considerations

This is an OAuth2 auth SDK for machine-to-machine access to the Auth0 My Organization API.

- **Token handling:** access tokens are obtained via `ITokenProvider` implementations (`ClientCredentialsTokenProvider`, `DelegateTokenProvider`) and injected as a per-request `Authorization: Bearer` header set dynamically in `MyOrganizationClient`. Never log, cache to disk, or serialize tokens or client secrets.
- **Private Key JWT:** `ClientCredentialsTokenProvider.WithClientAssertion` signs a JWT with a caller-provided `SecurityKey` (RS256/HS256). Keep private-key material in the caller's hands — the SDK never persists it.
- **Domain validation:** `MyOrganizationClient` rejects a `Domain` that includes a scheme or path (throws `ArgumentException`) to avoid malformed base URLs — preserve this validation.
- **Telemetry:** the `Auth0-Client` header (base64url JSON `{ name, version, env }`) is sent on every request. It carries no secrets — do not add token or PII fields to it.
- **Secret scanning:** Snyk (`.snyk`, `snyk.yml`) and ReversingLabs (`rl-secure.yml`) run in CI. Don't disable them to get a change through.

---

> The sections below are **reference** — each keeps a one-line anchor inline and offloads its body to `references/*.md`. Read a file only when the task needs it.

## Commands

Core commands (run from repo root):

```bash
dotnet restore Auth0.MyOrganizationApi.sln
dotnet build Auth0.MyOrganizationApi.sln --configuration Release --no-restore
dotnet test src/Auth0.MyOrganizationApi.Test/Auth0.MyOrganizationApi.Test.csproj
```

See [references/commands.md](references/commands.md) for the full command list (coverage, single-test filtering, clean). Read only when you need to build, test, or run coverage.

## Testing

- **Framework:** NUnit 4.5.1 (+ NUnit3TestAdapter, WireMock.Net for HTTP mocking). Coverage via coverlet (Cobertura → Codecov).
- **Location:** `src/Auth0.MyOrganizationApi.Test/`. The default `dotnet test` suite is **unit-only — no credentials required**; endpoint tests run against an in-process WireMock server, so no live Auth0 tenant is contacted.

See [references/testing.md](references/testing.md) for conventions, the WireMock mock-server pattern, and coverage details. Read when writing or debugging tests.

## Code Style

- **Naming:** `PascalCase` for types/methods/public properties, `_camelCase` for private fields, async methods suffixed `Async`. Enforced by `.editorconfig` (ReSharper/Roslyn hints) and NUnit.Analyzers.
- Generated models are `record` types with `[JsonPropertyName]` attributes and `required` init properties; optional fields use `[Optional]` + `Optional<T>`.

See [references/code-style.md](references/code-style.md) for good/bad examples, the error hierarchy, and dominant patterns. Read before adding hand-written code.

## Git Workflow

- **Commits:** Conventional Commits (`feat:`, `fix:`, `chore:`) — matches the existing history. All commits must be signed.
- **PRs:** target `main`; fill in the PR template (Changes / References / Testing / Checklist).

See [references/git-workflow.md](references/git-workflow.md) for branch naming, the release flow, and CHANGELOG format. Read when opening a PR or cutting a release.

## Common Pitfalls

Multi-target framework quirks (`DateOnly`/`net462`), the fernignore regeneration trap, and `Optional<T>` null semantics are the top gotchas.

See [references/pitfalls.md](references/pitfalls.md) for the full list. Read when a build breaks across target frameworks or an edit gets overwritten.

## Docs Update Rules

> A PR that adds or changes public API, configuration, or integration patterns is **not complete** until the relevant docs are updated in the same PR.

The "update README.md in the same PR" rule lives in Boundaries → Always Do. See [references/docs-update.md](references/docs-update.md) for the tracked-docs inventory and the code-to-docs mapping. Read when changing the public surface.
