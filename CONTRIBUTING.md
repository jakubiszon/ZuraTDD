# ZuraTDD - contributing guidelines

Discussions, issues and PRs are all welcome.

## Project structure

The solution contains the following projects:

- `ZuraTDD`: the main library and code generators.
- `ZuraTDD.Tests`: tests of ZuraTDD building blocks, not using code generation.
- `ExampleProject`: an example project with some classes and abstractions to test.
- `ExampleProject.Tests`: tests for the example project, using ZuraTDD code generation and the MSTest.
- `ExampleProject.XUnit`: a tiny project used to ensure the library is compatible with XUnit framework.

## Before you start
Please check the [issues on GitHub](https://github.com/jakubiszon/ZuraTDD/issues).
Some points listed here might already have a more detailed implementation idea.

## Before submitting code
- Please make sure any new code is covered by tests.
- Please build the solution in Release mode and run all tests.

## Things to do
Below there is a list of ideas to implement or consider in future versions.
Feel free to open discussions about them if you have any comments.

- TODOs - they are scattered across the codebase
- Add support for passing delegates as test subject dependencies - in such case, the mock needs to be a method instead of an object.
- Add indexer support for mocked objects.
- Add property support for mocked objects.
- Add event support for mocked objects.
- Add event detection and verification for test subjects.
- Add support for generic parameters in mocked objects.
- Add support for generic methods in test case classes.
- Add support for passing generic params from `TestCase` to dependencies.
- Add support for multiple Received calls.
- Add support for test-subject state expectations in TestCases.
	- Verify property values (e.g. List.Count after calling List.Add)
	- Verify indexer values
	- Verify field values
	- Verify enumerable states
- Verify usage of generic test case subjects.
- Add support for dynamic data types used in test cases and dependencies.
- Expand FuncBehaviorBuilder for async methods
	- Make sure to support Task\<T\> and ValueTask\<T\>
	- Add `Returns` overloads to bypass the need for `Task.FromResult` in tests.
- Replace `int` params inside `Insanity.IActionService` with something useful - ideally something which was breaking.

### Add testing framework adapters
At the moment this library can auto-generate tests but only for `MSTest` and `XUnit`.
It would be nice to add support for `NUnit`, `TUnit` and other frameworks.

The process of adding a new framework can be summarized as follows:
- Add another value to `ZuraTDD.TestFramework` enum.
- Add code to detect the framework in `ZuraTDD.TestGenerator.TestGenerator.DetectFramework` method.
- Extend `ZuraTDD.TestGenerator.TestTemplateProcessor.TestMethod` method to return code specific for the framework.
- Add extra test project to test and verify the added framework integration.

### Some ideas I already tried but never completed

- Adding manual `TestCase` builders.
    - My personnal opinion - it might be useful but I did not like it and decided to switch to more important features.
    - An implementation was started in this PR https://github.com/jakubiszon/ZuraTDD/pull/10 - which is still work in progress.
      The PR is "on-hold" for now and I would only want to pick it up if someone had a good use-case for the "test case builders".
    - The thing I tried was aimed to work similar to manual mock builders but output higher levels of abstractions e.g.
        - users could create instances of `MyTestCaseClassBuilder`
        - the builder included dependencies as its properties, similar to what we get when working with `When.` builder.
        - the builder defined `BuildInstance` and `BuildExpect` methods
        - the `expect` object would expose all dependencies as properites, similat to `Expect.` static builder.
    - The reasons I did not like this direction - it was making ZuraTDD similar to other mocking frameworks.
      It was also steering away from the "test parts are data" approach.
      It was moving the project towards imperative rather than declarative coding.
