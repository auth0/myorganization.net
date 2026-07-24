# Docs Update Rules

Treat documentation as a first-class deliverable. A PR that changes public API, configuration, or integration patterns is **not complete** until the relevant docs are updated in the same PR.

## Tracked docs

| File / location | What it covers | Exists |
|-----------------|----------------|--------|
| `README.md` | Installation, quick-start, auth flows (client credentials, private-key JWT, delegate/static token), pagination, request options, error handling, retries, telemetry | ✅ present |
| `EXAMPLES.md` | Runnable code samples | ❌ missing — the README's Usage section carries examples today. If you add `EXAMPLES.md`, keep it in sync with the public API. |

> `reference.md` is **generated** (Fern) — do not hand-edit it. `CHANGELOG.md` is cut during the release flow, not during feature PRs.

## When you change code, update these docs

This is a **library / SDK** — the public surface is the hand-written `Wrapper/` API plus the generated client methods.

| When this changes | Update these docs |
|-------------------|-------------------|
| Public API of `MyOrganizationClient` / token providers (`Wrapper/`) | `README.md` (Usage section) |
| Client configuration options (`MyOrganizationClientOptions`, `RequestOptions`) | `README.md` (Request Options / Base URL / Timeouts sections) |
| Authentication flow (new `ITokenProvider`, grant type, signing algorithm) | `README.md` (Getting Started / Usage) |
| Install / package name / target-framework requirements | `README.md` (Requirements / Installation) |
| A new public wrapper method or supported integration pattern added | `README.md` (add a usage sample) |
| A public wrapper method removed or renamed | `README.md` (remove/update references) |

> Generated client methods are documented in `reference.md` automatically — do not hand-edit. Focus doc updates on `README.md` and the hand-written wrapper surface.
