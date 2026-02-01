## ✅ Status (2026-02-01)

- `CodexModel.Default` now returns `"gpt-5.2"` (SDK default).
- Added `CodexModel.Gpt52Codex` (`"gpt-5.2-codex"`).
- `CodexModel.Gpt51Codex` is now an `[Obsolete]` alias for `Gpt52Codex` to avoid breaking existing callers.
- AppServer/McpServer stdio+JSON-RPC bootstrap + DI registrations were deduplicated (see `docs/Tasks/Unification/TASKS.md`).

## ✅ What you *did* complete (hard merge)

* **Deleted the dedicated library projects**: there is **no** `src/NCodexSDK.AppServer/NCodexSDK.AppServer.csproj` or `src/NCodexSDK.McpServer/NCodexSDK.McpServer.csproj` anymore.
* AppServer/McpServer code is now under:

  * `src/NCodexSDK/AppServer/*`
  * `src/NCodexSDK/McpServer/*`
* `NCodexSDK.sln` no longer references the deleted projects.
* `InternalsVisibleTo` was cleaned up correctly (only tests remain):
  `src/NCodexSDK/Properties/AssemblyInfo.cs`
* Demos reference the unified core project:

  * `src/NCodexSDK.AppServer.Demo/*.csproj` → `ProjectReference ..\NCodexSDK\NCodexSDK.csproj`
  * `src/NCodexSDK.McpServer.Demo/*.csproj` → same

So the “one library” goal is basically achieved.

---

## 🚨 Likely breaking: `CodexModel` constants vs tests are inconsistent

This is the biggest concrete issue I found.

### Current code

`src/NCodexSDK/Public/Models/CodexModel.cs` now says:

* `Default => "gpt-5.2"`
* `Gpt51Codex => "gpt-5.2-codex"`
* `Gpt51CodexMax => "gpt-5.1-codex-max"`
* `Gpt51CodexMini => "gpt-5.1-codex-mini"`
* `Gpt52 => "gpt-5.2"`

### Tests still expect the old values

`tests/NCodexSDK.Tests/Unit/CodexModelTests.cs` expects:

* `Default == "gpt-5.1-codex-max"`
* `Gpt51Codex == "gpt-5.1-codex"`
* etc.

So tests will fail (and this mismatch is also confusing semantically: `Gpt51Codex` returning a `gpt-5.2-*` string).

### Fix options (pick one)

**Option A (recommended for stability / least surprise):** keep existing constants stable

* Revert `CodexModel.Default` back to `"gpt-5.1-codex-max"`
* Revert `Gpt51Codex` back to `"gpt-5.1-codex"`
* If you want gpt-5.2 variants, add *new* properties (`Gpt52Codex`, etc.) instead of reusing `Gpt51*` names.

**Option B (if you really want to move defaults forward):** update tests + rename constants

* Update `CodexModelTests` assertions to match the new values.
* Strongly consider *adding* `Gpt52Codex` and making `Gpt51Codex` return `"gpt-5.1-codex"` again, otherwise the naming is misleading.

---

## ❗ “Shared infrastructure” is not done yet (still duplicated)

Even though everything is now in one assembly, the infrastructure is still duplicated in a few places:

### Duplicate bootstrap logic

* `src/NCodexSDK/AppServer/CodexAppServerClient.cs` (`StartAsync`) creates:

  * `RealFileSystem`
  * `DefaultCodexPathProvider`
  * `StdioProcessFactory`
  * `JsonRpcConnection`
* `src/NCodexSDK/McpServer/CodexMcpServerClient.cs` does the same.

And then the DI factories do similar wiring again:

* `src/NCodexSDK/AppServer/CodexAppServerClientFactory.cs`
* `src/NCodexSDK/McpServer/CodexMcpServerClientFactory.cs`

If your goal is “shared where possible,” you still want the shared `Stdio+JsonRpc` bootstrap helper (one internal class both modes call).

---

## ❗ DI registration is still duplicated (easy cleanup)

Right now you have three extension classes each registering common services:

* `src/NCodexSDK/Public/ServiceCollectionExtensions.cs` (`AddCodexClient`)
* `src/NCodexSDK/AppServer/ServiceCollectionExtensions.cs` (`AddCodexAppServerClient`)
* `src/NCodexSDK/McpServer/ServiceCollectionExtensions.cs` (`AddCodexMcpServerClient`)

Each one repeats:

* `services.TryAddSingleton<IFileSystem, RealFileSystem>()`
* `services.TryAddSingleton<ICodexPathProvider, DefaultCodexPathProvider>()`
* (and for server modes) `StdioProcessFactory`

If you want “shared infra,” factor that into one internal helper like `AddCodexCoreInfrastructure(services)` and call it from all three.

---

## ❗ The “nice façade” isn’t present yet

You asked for a façade plan earlier; in the zip I don’t see any of these (no `CodexSdk`, no builder, no `AddCodexSdk`):

* `CodexSdk`
* `CodexSdkBuilder`
* `CodexExecFacade` / `CodexAppServerFacade` / `CodexMcpServerFacade`
* `services.AddCodexSdk(...)`

So if you intended that to be part of this update, it’s missing.

---

## ⚠️ Minor: CI “Prepare NuGet README” step rewrites the wrong README

In `.github/workflows/ci.yml`, the “Prepare NuGet README” step rewrites **repo root** `README.md`.

But your package readme is configured from the **project**:

* `src/NCodexSDK/NCodexSDK.csproj` → `<PackageReadmeFile>README.md</PackageReadmeFile>`
* and packs `src/NCodexSDK/README.md`

So the CI rewrite step is currently **not affecting the readme that gets embedded** in the NuGet package.

Not fatal, but either:

* remove the step, or
* update it to rewrite `src/NCodexSDK/README.md` instead.

---

## ⚠️ Minor: demo package versions don’t match the library’s extensions stack

Core references `Microsoft.Extensions.*` **9.0.0** packages, while demos reference `Microsoft.Extensions.Logging.Console` **8.0.0**:

* `src/NCodexSDK.AppServer.Demo/NCodexSDK.AppServer.Demo.csproj`
* `src/NCodexSDK.McpServer.Demo/NCodexSDK.McpServer.Demo.csproj`

This might still work, but it’s cleaner to align them (especially if you’re standardizing around .NET 10 + latest extensions).

---

# Quick checklist of “missed” items to fix next

1. **Fix `CodexModel` vs unit tests mismatch** (this is the only “definitely broken” thing I see).
2. Extract **shared Stdio+JsonRpc bootstrap** and use it from:

   * AppServer `StartAsync` and factory
   * McpServer `StartAsync` and factory
3. Factor DI common registrations into one shared method (internal).
4. Add the **nice façade** (`CodexSdk` + builder + facades + `AddCodexSdk`).
5. Clean up CI README rewrite step (optional).
6. Align demo `Microsoft.Extensions.Logging.Console` package version (optional).

If you want, paste your intended decision for `CodexModel.Default` (keep at 5.1 max vs move to 5.2), and I’ll give you the exact minimal patch set (which files and what to change) that keeps compatibility while adding new 5.2 constants cleanly.
