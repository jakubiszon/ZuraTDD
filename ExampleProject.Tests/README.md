# Title
This project aims to reduce boiler-plate code and simplify setup of method-oriented unit-tests
in dotnet. The principles which I tried achieving are:

- Setup of tested-class dependencies is done behind the scenes.
- Setting up any dependency call takes a single line when we ignore input parameters.
- Irrelevant dependency call parameters do not need to be specified - I want to focus on the parts which matter.
- Reduce friction using Red-Green-Refactor TDD methodology by minimizing the
  parts which need adapting tests to refactored code.
- The tests are expressed in a simple way:
  ```C#
  new ExampleControllerTestCase(
      // name - specifies the name of the test case shown in reporting
      name: "TestedMethod - returns OK on happy path",

      // Receives - specifies the method and params that the tested-object receives.
      Receives.TestedMethod()
          .With<ExamplePayload>( payload ), // specifies ExamplePayload, ignores all other parameters

      // When - specifies the behavior of dependencies - return values, thrown exceptions, captured values.
      When.SomeRepo.ExampleMethod() // SomeRepo is named after the constructor parameter name of the tested-class
          .Returned( expectedDependencyResult ),

      ... // any number of When conditions can be specified

      // Expect - specifies the expectations for tested-method.
      Expect.ResultOfType<OkObjectResult>() // specifies the checks that occus after the tested-method completes its execution.

      Expect.Dependencies.AnotherDependency.AnotherMethod()
          .Called(3),

      ... // any number of Expect conditions can be specified
  );
  ```
