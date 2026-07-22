# ZuraTDD Development Roadmap

This roadmap shows feature status across the project. It is not complete.
It also should not be considered a commitment to implement listed features.

Legend:
- [x] completed features
- [ ] planned / partially done / needing research

## 1) Testing an object:

- [ ] Preparing test-subjects:
  - [x] Interface dependencies.
  - [x] Non-mockable dependencies - the `Is()` method of dependency builders.
  - [x] Passing delegates as test subject dependencies using the `.Is()` method.
  - [ ] Passing delegate dependencies prepared with `When` builders e.g. `When.DelegateDependencyName.Call( ... ).Returns( ... )`.
  - [ ] Setting initial property, field and indexer states of test-subjects.
- [x] Testing method calls are covered via the `Receives` builder.
  - [x] Allow passing parameter values.
  - [x] Allow skipping ignored parameters.
- [ ] Testing property calls - `Receives` builder needs to be extended.
- [ ] Testing indexer calls - `Receives` builder needs to be extended.
- [ ] Testing generics in test-subjects:
  - [x] Generic dependencies with known applied type arguments (e.g. `ILogger<MyClass>` inside `MyClass`)
  - [ ] Generic dependencies with test-case generic arguments applied e.g. `ISomeDependency<TSomething>` inside `MyClass<TSomething>`.
  - [ ] Testing generic methods of a non-generic test-subject.
  - [ ] Testing generic methods inside generic test-subject classes.
- [ ] Testing multiple `Receives` calls with different methods, properties and indexer interactions.

## 2) Mocking objects

- [x] Creating implicit mocks for test-subject classes.
- [x] Implementing explicit mocks declared by the user using `IMock<TMockedInterface>`.
- [x] Mocking simple interfaces.
- [x] Mocking generic methods in non-generic interfaces.
- [x] Mocking generic interfaces.
- [x] Mocking generic methods in generic interfaces.
- [x] Mocking methods - up to 16 parameters.
- [ ] Mocking properties.
- [ ] Mocking indexers.
- [ ] Mocking events - to be decided if needed.
- [ ] `dynamic` method parameters in mocked methods.
- [ ] `Span<T>`, `ReadOnlySpan<T>`, and other `ref struct` parameters in mocked methods.
- [ ] `out`, `in` and `ref` parameters in mocked methods.
- [ ] `params` arrays in mocked methods.

## 3) Verifying tests using `Expect` builder classes

- [x] Testing method return values:
  - [x] Matching exact values - `Expect.ResultEqualTo(value)`.
  - [x] Matching predicates - `Expect.ResultMatching<T>(Predicate<T>)`.
  - [ ] Simplify verifying data streamed through `IAsyncEnumerable<T>`.
  - [ ] Checking `out` and `ref` parameters.
- [ ] Testing thrown exceptions:
  - [x] Thrown exceptions by type.
  - [ ] Thrown exceptions by predicate.
- [x] Testing method calls on mocked dependencies:
  - [x] Method calls - any expected `.WasCalled()`.
  - [x] Method calls - exact count expected `.WasCalled(times)`.
  - [x] Method calls - none expected `.WasNotCalled()`.
- [x] Testing received call parameters
  - [x] Matching exact values.
  - [x] Matching predicates.
  - [x] Alow skipping ignored values.
- [x] Testing received call generic arguments
  - [x] Matching exact generic arguments.
  - [x] Matching *any* and other generic argument filters.
- [ ] Testing calls to delegates passed to the test-subject constructor.
- [ ] Testing events emitted from the test-subject.
- [ ] Testing method calls to mocks returned from mocked objects.
- [ ] Testing test-subject state:
  - [ ] Property values.
  - [ ] Indexer values.
  - [ ] Field values.
  - [ ] Enumerable state values.
  - [ ] It could all be covered with something like `Expect.TestSibjectState(Predicate<TestSubject>)`.
- [ ] Testing free-form side effect conditions - e.g. something like `Expect.ToBeTrue(Func<bool>)`.
- [ ] Expecting dependency calls to happen in a predefiined order.
- [ ] Expecting a stricy set of dependency calls - calls not covered with the set should fail the test.
- [ ] Allow user-code to examine recorded calls (dependencies + methods + generic arguments + parameter values) - requires research.
- [ ] There are a lot of features in the `Expect` builder - possible identifier conflicts need research.

## 4) Setting up dependency and mocked object behaviors

- [x] Returning values from mocked methods.
  - [x] Passing predefined values.
  - [x] Factory methods using mocked method parameters to produce the value.
  - [x] Simpler async return values - `ReturnsInTask`, `ReturnInValueTask`
  - [ ] Simplify setting up `IEnumerable<T>` method results.
  - [ ] Simplify setting up `IAsyncEnumerable<T>` method results.
- [x] Calling side effects from mocked methods.
  - [x] Simple parameter-less callbacks.
  - [x] Callbacks accepting mocked method parameters.
- [x] Throwing exceptions from mocked methods.
  - [x] Passing the exception to throw directly.
  - [x] Factory methods consuming mocked method parameters to produce the exception.
  - [x] Simpler async exception throwing - `ThrowsFromTask`, `ThrowsFromValueTask`
- [x] Chaining behaviors.
- [x] Matching mocked method parameters.
  - [x] Matching exact values.
  - [x] Matching predicates.
  - [x] Alow skipping ignored values.
- [x] Matching mocked method generic arguments.
  - [x] Matching exact types.
  - [ ] Matching *any* and other generic argument filters.
    This could be useful to setup *catch-all-types* behaviors e.g. to throw an exception.

## 5) Testing framework and IDE integrations

- [x] Using `[ZuraTestClass]` and `[ZuraTest]` attributes to auto-generate tests:
  - [x] MSTest support.
  - [x] xUnit support.
  - [ ] NUnit support.
  - [ ] TUnit support.
  - [ ] Other frameworks.
  - [ ] Allow maual framework choice - IF there are problems found with automatic framework detection.
- [x] Emitting errors for possible user mistakes - mostly done.
- [ ] IDE error documentation - in progress.
- [ ] Quick fix suggestions.
- [ ] Codebase navigation improvements and documentation - needs researching.
- [ ] Improve `ExpectedResultMatching` failure details when expression-based predicates are used.
- [ ] Improve `ExpectedMethodCall` failure output.

## 6) Performance improvements

- [ ] Avoid creating fakes when an abstract dependency is provided as a named instance.
- [ ] Revisit `ThrowBehavior` validation strategy (runtime validation vs analyzer-driven compile-time diagnostics).
- [ ] Optimize `ValueConstraint` generic type matcher initialization strategy.
