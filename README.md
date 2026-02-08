# ZuraTDD
A testing library designed to reduce friction in red-green-refactor
methodology in dotnet:

- Reduces boilerplate code when setting up dependencies:
    - Uses code generators to create mocks and test case objects.
    - Generated mocking methods match signatures of mocked types.
    - But they allow passing parameters which matter and ignoring the rest.
- Expresses conditions and expectations clearly.
- Makes tests serve as documentation for the codebase.
- Can be used with MSTest, NUnit, xUnit and any other test framework.

## Test Cases
You can use ZuraTDD to create test cases which set up mocks and expectations in a clear way.

```csharp
// Declare a partial class which inherits from TestCase<T>
// You say what you want to test and get
public partial class MyConstrollerTestCase
    : TestCase<MyController>
{
}
```

Now you get auto-generated code for setting up mocks.
You can now write tests like this:

```csharp
// static using makes it easy to access the Received, When and Expect classes.
using static MyConstrollerTestCase;

[TestClass]
public class MyControllerTests
{
    [TestMethod]
    [DynamicData(nameof(HandleTestsData), DynamicDataSourceType.Method)]]
    public async Task HandleTests(MyConstrollerTestCase testCase)
    {
        await testCase.RunTestAsync();
    }

    public static IEnumerable<object[]> HandleTestsData()
    {
        yield return new object[]
        {
            new MyConstrollerTestCase
            {
                name: "example test name",

                // first - specify what call the test subject receives
                Receives.Handle(),

                When.CustomerRepository
                    .GetCustomer() // you can skip params unless you want to match them
                    .Throws<ExampleTestException>(),

                Expect.Exception<ExampleTestException>(),

                Expect.EmailSender
                    .SendEmail()
                    .
            }
        };
    }
}
```

## Mocking
You can use ZuraTDD to mock objects directly.

```csharp
// Declare a partial implementing IMock<T>.
internal partial class MyMock
    : IMock<IMyInterface>
{
}
```

You can use it in your tests:
```csharp
[TestMethod]
public void MyTest()
{
    var (setup, buildInstance, buildExpect) = new MyMock();

    // most specific filters go first
    setup.GetCustomer(id: 1)
        .Returns(new Customer(1, "Ivan", "Catrump"));

    // you can use any expression to filter parameters, not just values
    setup.GetCustomer(id: new(x => x > 1 && x < 10))
        .Returns(new Customer(2, "Kamma", "Laharris"));

    // the widest filters should go last
    // all parameters can be skipped if you don't want to match them
    setup.GetCustomer()
        .Throws(() => new ExampleException());


    var sut = buildInstance();

    var ivan = sut.GetCustomer(1);
    Assert.AreEqual("Ivan", ivan.FirstName);

    Assert.ThrowsException<ExampleException>(
        () => sut.GetCustomer(11));


    var expect = buildExpect();
    expect.GetCustomer(id: new(x => x < 20)
        .WasCalled(times: 2);

    // id == 777 was not used
    expect.GetCustomer(id: 777)
        .WasNotCalled();

    // parameters can be ignored when specifying expectations
    // NOTE: this check will fail because we called the method 2 times
    expect.GetCustomer()
        .WasCalled(times: 3);
}
```
## Documentation

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
- Max input parameter count for mocked methods is 16 - if you really need more contributions are welcome :D
- No support for `Span<T>`, `ReadOnlySpan<T>` and other `ref struct` types used as mocked object method parameters.
- No support for `dynamic` used used as mocked object method parameter.

Some of the above are planned in the near future, but feel free to contribute if you want to see them sooner.

## Contributing
Contributions are welcome! Please see the [CONTRIBUTING.md](CONTRIBUTING.md) file for guidelines.
