# ZuraTDD

A testing / mocking library designed to write concise, declarative **unit-tests** in dotnet.


![Simple, declarative test](https://github.com/jakubiszon/ZuraTDD/raw/main/Documentation/example-test.png)


What ZuraTDD does for you:
- It reduces boilerplate code when setting up tests:
    - Its code generators create objects testing your code.
    - You get `Receives` builder to specify what method is under test and how it is invoked.
    - You get `When` builder to make expressing dependency behaviors easy.
    - You get `Expect` builder which make it trivial to tell what your code is expected to do.
    - Creating *fake* objects, the *test subject* class and connecting things together to test *expected outcomes* is done by the generator.
- It helps making tests serve as documentation for the codebase.
- It makes it much easier to employ red-green-refactor TDD approach in your development process.
- It does not add extra dependencies to your codebase. Only `Microsoft.CodeAnalysis` packages are used by this library.
- It can be used with MSTest, NUnit, xUnit or any other test framework.

Note: ZuraTDD is still in development but its public API is not planned to change. Some of the limitations of this project are listed at the end of the readme.

Check out the [repository](https://github.com/jakubiszon/ZuraTDD) on GitHub.

## Quick Start
1) Install the nuget package.
    ```
    dotnet add package ZuraTDD --version 1.0.8
    ```
1) Decorate a test class with `ZuraTestClass` attribute:
    ```cs
    // tells ZuraTDD to generate builders for the MyTodosController class
    [ZuraTestClass<MyTodosController>]
    public partial class MyTestClass
    {
    }
    ```
1) Inside your test class - define a test using `ZuraTest` attribute:
    ```cs
    // tells ZuraTDD to use this member as a source of test steps
    [ZuraTest("CreateTodo - when no errors - succeeds.")]
    private ITestPart[] CreateTodo_SuccessPath => [
        // Receives builder is auto-generated, use it to tell what method to test
        Receives.CreateTodo(payload: new TodoModel(...)),

        // When builder is used to tell how do dependencies behave
        When.TodoRepository.Exists() // skipping parameters will match any call to .Exists()
            .ReturnsInTask(false),

        When.TodoRepository.Insert() // skipping params, matching any call to .Insert()
            .Returns(Task.CompletedTask),

        Expect.ResultMatching<StatusCodeResult>(result => result.StatusCode == 201),
    ];
    ```
    That's it - you have a working test!

## More complex example

If we wanted to test the following class:
```csharp
public class SendEmailController(
    // generated dependencies will use names used by constructor parameters
    ICustomerRepository customerRepository,
    IEmailSender emailSender)
{
    Task<IActionResult> SendEmailToCustomer(
        int customerId,
        int emailTemplateId,
        Dictionary<string, string> templateParameters)
    { ... }
}
```

We could define the test class like this:

```csharp
using ZuraTDD;

[TestClass]
[ZuraTestClass<SendEmailController>]
public partial class SendEmailControllerTests
{
    [ZuraTest("SendEmailToCustomer throws when EmailSender throws.")]
    public static IEnumerable<ITestPart> SendEmailToCustomer_ThrowsWhenEmailSenderThrows()
    => [
        // first - specify what call the test subject receives
        // you can skip parameters - default value will be used
        // the idea is to specify only parameters relevant for the test
        Receives.SendEmailToCustomer(),

        // GetCustomer - returning a customer
        When.CustomerRepository
            // you can skip params unless you want to match them
            .GetCustomer()
            .Returns(Task.FromResult(new Customer(123, "Emma", "Nuelmacron"))),

        // let's simulate SendEmail to throw
        When.EmailSender
            .SendEmail()
            .Throws(new ExampleTestException()),

        // in this case - we expect the tested class to propagate the exception
        Expect.ExceptionToBeThrown<ExampleTestException>(),

        // let's verify that GetCustomer was called exactly once
        Expect.CustomerRepository
            .GetCustomer()
            .WasCalled(times: 1)

        // we set no return-value expectations, because the method was expected to throw
    ];

    [ZuraTest("SendEmailToCustomer sends an email using customer data.")]
    public static IEnumerable<ITestPart> SendEmailToCustomer_SendsEmailUsingCustomerData()
    => [
        // first - specify what call the test subject receives
        // you can skip parameters - default value will be used
        // the idea is to specify only parameters relevant for the test
        Receives.SendEmailToCustomer(
            customerId: 123,
            emailTemplateId: 456),

        // GetCustomer - returning a customer
        When.CustomerRepository
            .GetCustomer(123)
            .Returns(Task.FromResult(new Customer(123, "emma.nuelmacron@example.com"))),

        // SendEmail - succeeds
        When.EmailSender
            .SendEmail()
            .Returns(Task.CompletedTask),

        // let's verify that GetCustomer was called exactly once
        Expect.CustomerRepository
            .GetCustomer(123)
            // we specify the exact number of calls here
            .WasCalled(times: 1)

        // let's confirm that a call with the right data was made to SendEmail
        Expect.EmailSender
            .SendEmail(
                to: "emma.nuelmacron@example.com",
                emailTemplateId: 456)
            // no param below - checks for at least 1 call
            .WasCalled()

        // Let's check that the method returned success.
        // note: ResultMatching type param must match the return type as declared by the tested method.
        Expect.ResultMatching<IActionResult>(
            result => result is OkObjectResult)
    ];
}
```

## Documentation

- [Behaviors](https://github.com/jakubiszon/ZuraTDD/blob/main/Documentation/Behaviors.md)
- [Expectations](https://github.com/jakubiszon/ZuraTDD/blob/main/Documentation/Expect.md)
- [Matching calls](https://github.com/jakubiszon/ZuraTDD/blob/main/Documentation/CallMatching.md)
- [`ZuraTest` and `ZuraTestClass` attributes](https://github.com/jakubiszon/ZuraTDD/blob/main/Documentation/ZuraTest.md)
- [IDE errors](https://github.com/jakubiszon/ZuraTDD/blob/main/Documentation/IDEErrors.md) ⚠️ section under construction
- [Testing framework integration](https://github.com/jakubiszon/ZuraTDD/blob/main/Documentation/Frameworks.md)
- [Code navigation](https://github.com/jakubiszon/ZuraTDD/blob/main/Documentation/Navigation.md) ⚠️ section under construction

More advanced features which might not be necessary for every user:
- [Mocking](https://github.com/jakubiszon/ZuraTDD/blob/main/Documentation/Mocking.md) - using custom mock objects not generated by default when `ZuraTestClass` are implemented.
- [Test Cases](https://github.com/jakubiszon/ZuraTDD/blob/main/Documentation/TestCases.md) - using ZuraTDD to create TestCase classes only.


## Limitations
This library is still in development and has some limitations:

- No indexer or property support in mocked objects yet.
- Partial generic types support:
    - [x] Generic methods inside mocked / dependency classes.
    - [x] Generic mocked / dependency types e.g. `ILogger<TCategoryName>`.
    - [ ] Generic methods inside test subject classes.
    - [ ] Generic test subject classes.
- All classes implementing `IMock<T>` and `ITestCase<T>` need to be placed in the same namespace.
- All classes implementing `IMock<T>` and `ITestCase<T>` need to be declared as `partial` and `internal`.
- Max input parameter count for mocked methods is 16 - if you really need more - contributions are welcome :D
- No support for `Span<T>`, `ReadOnlySpan<T>` and other `ref struct` types used as mocked object method parameters.
- No support for `dynamic` used as mocked object method parameter.

Some of the above are planned in the near future, but feel free to contribute if you want to see them sooner.

## Contributing
Contributions are welcome! Please see the [CONTRIBUTING.md](https://github.com/jakubiszon/ZuraTDD/blob/main/CONTRIBUTING.md) file for guidelines.

## License
This project is licensed under the Apache 2.0 License - see the [LICENSE](LICENSE) file for details
