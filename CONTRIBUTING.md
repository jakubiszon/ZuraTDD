# Project structure

The solution contains the following projects:

- `ZuraTDD`: the main library and code generators.
- `ZuraTDD.Tests`: tests of ZuraTDD building blocks, not using code generation.
- `ZuraTDD.MsTest`: a little library with MsTest-specific helpers.
- `ExampleProject`: an example project with some classes and abstractions to test.
- `ExampleProject.Tests`: tests for the example project, using ZuraTDD code generation and the MSTest helpers.


## Things to do
- TODOs.
- Add indexer support for mocked objects.
- Add property support for mocked objects.
- Add support for generic methods in mocked objects.
- Add support for generic methods in test case classes.
- Add support for multiple Received calls.
- Add support for test-subject state expectations in TestCases.
	- Verify property values (e.g. List.Count after calling List.Add)
	- Verify indexer values
	- Verify field values
	- Verify enumerable states
- Add support for setting up properties in mocked objects.
- Verify usage of generic test case subjects.
- Add support for dynamic data types used in test cases and dependencies.
- Add adapters for XUnit.
- Add adapters for NUnit.
- Add adapters for other frameworks.
- Expand FuncBehaviorBuilder for async methods
	- Make sure to support Task\<T\> and ValueTask\<T\>
	- Add `Returns` overloads to bypass the need for `Task.FromResult` in tests.
- Replace `int` params inside `Insanity.IActionService` with something useful - ideally something which was breaking.
