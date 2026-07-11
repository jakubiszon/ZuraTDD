# AGENTS.md

## Project

ZuraTDD is a .NET testing/mocking library that uses Roslyn source generators to auto-generate test scaffolding. It targets `netstandard2.0` (for analyzer compatibility) and generates tests for `net10.0` projects. Supports MSTest and xUnit.

## Build & Test

```bash
dotnet restore
dotnet build ZuraTDD.slnx --no-restore --configuration Release
dotnet test --solution ZuraTDD.slnx --no-build --configuration Release --verbosity normal
```

Solution file: `ZuraTDD.slnx` (not `.sln`).

## Project Structure

- `ZuraTDD/` -- Main library and Roslyn source generators. Targets `netstandard2.0`. NuGet package ID: `ZuraTDD`.
- `ZuraTDD.Tests/` -- Unit tests for ZuraTDD internals (MSTest, net10.0).
- `ZuraTDD.CompilationTests/` -- Tests of the DataModel objects with manual compilation (MSTest, net10.0). Useful for debugging generators.
- `ExampleProject/` -- ASP.NET Core example app used as test subject (net10.0).
- `ExampleProject.Tests/` -- Example tests using MSTest + ZuraTDD code generation (net10.0).
- `ExampleProject.XUnit/` -- Example tests using xUnit + ZuraTDD code generation (net10.0).
- `Documentation/` -- Markdown docs for API topics.
- `.github/workflows/` -- CI: builds and tests on PRs.

## Key Concepts

### Source Generator 1: `TestSubjectSourceGenerator`

Scans for classes implementing `ITestCase<T>` or `IMock<T>` (must be `partial`).

- **`ITestCase<TSubject>`** -- Marker interface. A `partial class` implementing this gets auto-generated:
  - `TestCase<TSubject, TDependencies>` base class
  - Nested `Receives` static class (factory methods for tested method calls)
  - Nested `When` static class (property accessors returning behavior builders for each dependency)
  - Nested `Expect` static class (property accessors for expectations + built-in `ExceptionToBeThrown<T>()`, `ResultMatching<T>()`)
  - Dependencies class implementing `ITestSubjectDependencies`

- **`IMock<TType>`** -- Marker interface. A `partial class` implementing this gets auto-generated:
  - `Mock` class with `Setup` property and `Deconstruct`
  - Builder class with fluent method setup + `BuildInstance()`
  - Fake implementation extending `MockedObject`
  - Expectation builders with `WasCalled()` / `WasNotCalled()` / `WasCalled(int)`

### Source Generator 2: `TestGenerator`

Scans for methods/properties decorated with `[ZuraTest<TTestCase>]` that return `ITestPart[]` or `IEnumerable<ITestPart>`. Auto-detects MSTest vs xUnit by checking for `Xunit.FactAttribute`.

## Code Conventions

- **Indentation:** Tabs in C# files (see `.editorconfig`).
- **File-scoped namespaces:** `namespace ZuraTDD;`
- **Nullable:** Enabled across all projects.
- **Naming:** PascalCase for types/methods/properties. camelCase for private fields (no underscore prefix).
- **`TreatWarningsAsErrors`:** Enabled in non-Debug configurations.
- **Generated code patterns:** Source generators use raw string literals with `$$"""` (double-dollar interpolated). Generated classes are `internal partial class`.
- **`IMock<T>` and `ITestCase<T>` implementations:** Must be `partial` and `internal`, placed in the same namespace as the subject type.
- **System usings first:** `dotnet_sort_system_directives_first = true`.

## Boundaries

- Never modify files in `.vs/`, `bin/`, `obj/`, `TestResults/`.
- Never commit secrets or API keys.
- The main library targets `netstandard2.0` -- do not use C# features requiring newer runtimes there (check `LangVersion` is `latest` but runtime is netstandard2.0).
- Do not add runtime dependencies to the main `ZuraTDD` project -- it only uses `Microsoft.CodeAnalysis.*` packages.
- `ExampleProject.Tests` and `ExampleProject.XUnit` reference ZuraTDD as an `Analyzer` (not just a project reference) -- this is intentional for source generation to work.
