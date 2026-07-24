# Git Workflow

## Branches

- `main` is the default and release base.
- Feature/fix branches follow `feat/<TICKET>`, `fix/<slug>`, `chore/<slug>` (matches history, e.g. `feat/SDK-8401`, `chore/update-deps`).
- Release branches: `release/<version>` (e.g. `release/1.0.0`).

## Commits

- **Conventional Commits:** `feat:`, `fix:`, `chore:`, etc. Keep the subject imperative and scoped.
- **All commits must be signed** (per the PR template checklist).

## Pull Requests

- Target `main`.
- Fill in `.github/workflows/PULL_REQUEST_TEMPLATE.md`: **Changes** (what/why, API surface added/removed/changed), **References** (ticket/forum links), **Testing** (how to verify; check the unit/integration/tested boxes), **Checklist** (contribution guidelines, signed commits).
- CI that must pass: Build and Test (`build.yml`), Snyk (`snyk.yml`), RL-Secure (`rl-secure.yml`).
- This SDK is **generated** — direct additions to generated files won't be merged as-is; they must move into the generator. Open a PR as a proof of concept and discuss in an issue first.

## Changelog

- `CHANGELOG.md` follows Keep-a-Changelog style (`## [version](tag) (date)` with **Added / Changed / Removed** groups; breaking items prefixed `**Breaking:**`).
- Changelog entries are cut as part of the **release** flow, not hand-edited during a feature PR.

## Release / versioning

- Releases are cut via the release tooling (`.shiprc`, `release.yml`, `nuget-release.yml`), not by an agent editing files.
- Version source of truth is `.version`; the `.shiprc` bump also updates `src/Auth0.MyOrganizationApi/Auth0.MyOrganizationApi.csproj`, `Auth0.MyOrganizationApi.Custom.props`, and `src/Auth0.MyOrganizationApi/Core/Public/Version.cs`. Keep all of them in sync — never edit one alone.
