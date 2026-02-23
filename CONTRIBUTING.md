# ZuraTDD - contributing guidelines

Discussions, issues and PRs are all welcome.

# Project structure

The solution contains the following projects:

- `ZuraTDD`: the main library and code generators.
- `ZuraTDD.Tests`: tests of ZuraTDD building blocks, not using code generation.
- `ZuraTDD.MsTest`: a little library with MsTest-specific helpers.
- `ExampleProject`: an example project with some classes and abstractions to test.
- `ExampleProject.Tests`: tests for the example project, using ZuraTDD code generation and the MSTest helpers.


## Things to do
Below there is a list of ideas to implement or consider in future versions.
Feel free to open discussions about them if you have any comments.

- TODOs - they are scattered across the codebase
- Add support for passing delegates as test subject dependencies - in such case, the mock needs to be a method instead of an object.
- Add indexer support for mocked objects.
- Add property support for mocked objects.
- Add event support for mocked objects.
- Add support for generic methods in mocked objects.
- Add support for generic parameters in mocked objects.
- Add support for generic methods in test case classes.
- Add support for passing generic params from `TestCase` to dependencies.
- Add support for multiple Received calls.
- Add support for test-subject state expectations in TestCases.
	- Verify property values (e.g. List.Count after calling List.Add)
	- Verify indexer values
	- Verify field values
	- Verify enumerable states
- Add support for setting up properties in mocked objects.
- Verify usage of generic test case subjects.
- Add support for dynamic data types used in test cases and dependencies.
- Expand FuncBehaviorBuilder for async methods
	- Make sure to support Task\<T\> and ValueTask\<T\>
	- Add `Returns` overloads to bypass the need for `Task.FromResult` in tests.
- Replace `int` params inside `Insanity.IActionService` with something useful - ideally something which was breaking.
- Would it make sense to add `TestCaseBuilder` class?
	- It could implement `IBuild<TestCaseClass>`
    - It could implement `IBuild<TestCaseServices>`
	- It could build services when building the test-case
    - It might be useful to have a builder of specific class dependencies
      and be able to use outside the context of a `TsstCase`

### Add testing framework adapters
- Add `TestFramework` enum to list supported test frameworks.
- Add `TestCaseAttribute(TestFramework, string testName)` to mark test cases declared as standalone tests.
- Ensure the above are used inside `partial` classes.
- Generate test methods for the above, example for MSTest:
  ```csharp
  [TestMethod(DisplayName: "use the name here")]
  public async Task TestCaseAsNamedInUserCode__Test()
  {
      await TestCaseAsNamedInUserCode.RunTestAsync();
  }
  ```
