# ZuraTDD
A testing / mocking library designed to reduce friction in red-green-refactor
methodology in dotnet:

- It reduces boilerplate code when setting up dependencies:
    - Uses code generators to create *mocks* and *test case* objects.
    - `TestCase` objects expose builders letting you focus on tests logic and get boilerplate code for free.
    - `Fake / Mock` objects use builders which help focusing on data which is relevant to the test.
    - Creating *test subject* and *fake* instances are done by the generator
      freeing you from repeating the same code in every test.
- It allows expressing conditions and expectations clearly.
- It helps making tests serve as documentation for the codebase.
- It can be used with MSTest, NUnit, xUnit or any other test framework.
- It does not add extra dependencies to your codebase. Only `Microsoft.CodeAnalysis` packages are used by this library.

The codebase is still in early stages of development, but the main concepts are already implemented and can be used in tests.
Check out the [repository](https://github.com/jakubiszon/ZuraTDD) on GitHub.

Limitations of this project are listed at the end of the readme.

## Test Cases
You can use ZuraTDD to create `TestCase` classes.
Your test-case classes will receive auto-generated test *builders* which help you express:
- method called and tested on the class which is the subject of the test-case - defined using `Receives` builder
- test-subject dependency behaviors - defined using `When` builder
- expectations for test-subject's interactions with its dependencies as well as expectations for
  the result returned from the tested method - defined with `Expect` builder

```csharp
// Declare an internal partial class which implements ITestCase<T>
// The type parameter is the class to test.
internal partial class SendEmailControllerTestCase
    : ITestCase<SendEmailController>
{
}
```

If the `SendEmailController` has following signature:
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

Now you get auto-generated code for setting up mocks and can now write tests like this:

```csharp
// static import - easy access to "Received", "When" and "Expect" classes
// which were generated for the test case
using static SendEmailControllerTestCase;
using ZuraTDD;

[TestClass]
public class SendEmailControllerTests
{
    [TestMethod]
    [DynamicData(nameof(Handle_TestsData))]
    public async Task SendEmailToCustomer_Tests(TestCase testCase)
    {
        await testCase.RunTestAsync();
    }

    public static IEnumerable<object[]> SendEmailToCustomer_TestsData()
    {
        // you can yield return instances of SendEmailControllerTestCase directly
        // they are automatically converted to object[]
        yield return new SendEmailControllerTestCase
        {
            name: "SendEmailToCustomer throws when EmailSender throws.",

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
                .Throws(() => new ExampleTestException()),

            // in this case - we expect the tested class to propagate the exception
            Expect.ExceptionToBeThrown<ExampleTestException>(),

            // let's verify that GetCustomer was called exactly once
            Expect.CustomerRepository
                .GetCustomer()
                .WasCalled(times: 1)

            // we set no return-value expectations, because the method was expected to throw
        };

        yield return new SendEmailControllerTestCase
        {
            name: "SendEmailToCustomer sends an email using customer data.",

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

            // let's verify that GetCustomer was called
            Expect.CustomerRepository
                .GetCustomer(123)
                .WasCalled(times: 1)

            // let's confirm that a call with the right data was made to SendEmail
            Expect.EmailSender
                .SendEmail(
                    to: "emma.nuelmacron@example.com",
                    emailTemplateId: 456)
                // WasCalled with no param checks for at lease 1 call
                .WasCalled()

            // Let's check that the method returned success.
            // note: ResultMatching type param must match the return type as declared by the tested method.
            Expect.ResultMatching<IActionResult>(
                result => result is OkObjectResult)
        };
    }
}
```

## Mocking
You can also use ZuraTDD to mock objects directly. You will get the same kind of builders as the ones used for dependencies in the `When` builder of the `TestCase` objects.

```csharp
// Declare an internal partial class implementing IMock<T>.
internal partial class MyMock
    : IMock<IMyInterface>
{
}
```
Assuming the `IMyInterface` has the following signature:
```csharp
public interface IMyInterface
{
    Customer GetCustomer(int id);
}
```


You can use it in your tests:
```csharp
[TestMethod]
public void MyTest()
{
    // setup - is used to define behaviors
    // buildInstance - creates an instance of IMyInterface after the setup is completed
    // buildExpect - creates an expect object to verify calls to the IMyInterface instance
    var (setup, buildInstance, buildExpect) = new MyMock();

    // most specific filters go first
    setup.GetCustomer(id: 1)
        .Returns(new Customer(1, "Ivan", "Katrump"));

    // you can also use expressions to match parameters values
    setup.GetCustomer(id: new(x => x > 1 && x < 10))
        .Returns(new Customer(2, "Kama", "Laharris"));

    // the widest filters / "match all" should go last
    // all parameters can be skipped if you don't want to match them
    setup.GetCustomer()
        .Throws(() => new ExampleException());

    // build the mocked object instance - this should always be called after setting up behaviors
    // it should be passed to tested code as a dependency
    // but here we will play with it directly to show how it works
    var myInterfaceInstance = buildInstance();

    // this call matches the first behavior-setup
    // it will return Ivan Katrump customer instance
    var ivan = myInterfaceInstance.GetCustomer(1);
    Assert.AreEqual("Ivan", ivan.FirstName);

    // the following call matches the last behavior-setup
    // and results in an exception
    Assert.ThrowsException<ExampleException>(
        () => myInterfaceInstance.GetCustomer(11));

    // build expect object - it allows checking calls and parameter values
    // which the mocked object received
    var expect = buildExpect();
    expect.GetCustomer(id: new(x => x < 20)
        .WasCalled(times: 2);

    // id == 777 was not used
    expect.GetCustomer(id: 777)
        .WasNotCalled();

    // parameters can be ignored when specifying expectations
    // ignoring all parameters will "count all calls to the method"
    // NOTE: this check will fail because we called the method 2 times, not 3
    expect.GetCustomer()
        .WasCalled(times: 3);
}
```
## Documentation

Installation is simple - just add the package to your test project:
```sh
# Install from NuGet.org
dotnet add package ZuraTDD
```

Documentation topics:
- [Behaviors](./Documentation/Behaviors.md)
- [Matching calls](./Documentation/CallMatching.md)
- [Expectations](./Documentation/Expect.md) ⚠️ section under construction
- [Mocking](./Documentation/Mocking.md) ⚠️ section under construction
- [Test Cases](./Documentation/TestCases.md) ⚠️ section under construction
- [Code navigation](./Documentation/Navigation.md) ⚠️ section under construction


## Limitations
This library is still in development and has some limitations:

- No indexer or property support in mocked objects yet.
- No support for generic methods yet.
- All classes implementing `IMock<T>` and `ITestCase<T>` need to be placed in the same namespace.
- All classes implementing `IMock<T>` and `ITestCase<T>` need to be declared as `partial` and `internal`.
- Max input parameter count for mocked methods is 16 - if you really need more - contributions are welcome :D
- No support for `Span<T>`, `ReadOnlySpan<T>` and other `ref struct` types used as mocked object method parameters.
- No support for `dynamic` used as mocked object method parameter.

Some of the above are planned in the near future, but feel free to contribute if you want to see them sooner.

## Contributing
Contributions are welcome! Please see the [CONTRIBUTING.md](CONTRIBUTING.md) file for guidelines.

## License
This project is licensed under the Apache 2.0 License - see the [LICENSE](LICENSE) file for details
