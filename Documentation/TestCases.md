# Zura TDD `TestCase` objects

When you declare a class as implementing `ITestCase<TSubject>` - you are defining a test case object.
This object will receive an auto-generated constructor and builders for its constructor dependencies / parameters.

```csharp
// example class we want to test
public class ContentPublishedEventHandler
{
    public ContentPublishedEventHandler(
        ICustomerRepository customerRepository,
        IEmailSender emailSender)
    {
        // constructor code
    }

    // example method
    public async Task HandleContentPublish(Content content)
    {
        // method code
    }
}

// example test case object
public partial class ContentPublishedEventHandlerTestCase
    : ITestCase<ContentPublishedEventHandler>
{
    // no code required here - everything will be auto-generated
}
```

What you get is:
- `Receives` builder - which allows specifying the tested method and how it is invoked.
  In the example above, it will expose:
  - `Receives.HandleContentPublish`
- `When` builder - which allows setting up dependenecies and their behaviors.
  Every constructor parameter will have its own builder inside the `When`. In the example above, you will get:
  - `When.CustomerRepository` - it will expose methods of `ICustomerRepository` and allow you to set up their behaviors.
  - `When.EmailSender` - it will expose methods of `IEmailSender` and allow you to set up their behaviors.
- `Expect` builder - it allows you to set up expectations for interactions with dependencies as well as for the value returned from the tested method.
  Every interface which is a constructor parameter will have its own builder inside the `Expect`.
  - `Expect.CustomerRepository` - it will expose methods of `ICustomerRepository` and allow you to set up expectations for their invocations.
  - `Expect.EmailSender` - it will expose methods of `IEmailSender` to allow you setting up expectations for their invocations.
  - `Expect.ResultMatching<TResult>(Predicate<TResult> predicate)` - allows you to specify a predicate to match against the value returned from the tested method.
  - `Expect.ResultEqualTo<TResult>(TResult expectedValue)` - allows you to specify equality match expectation for the tested method result.

## TestCase object structure
Other than exposing the builders - the `TestCase` defines a constructor
and a method `RunTestAsync` which runs the test.
There is no synchronous version of this method - it is always `async` even if the tested methos is not.

```csharp
// the constructor will always look the same for all TestCase objects:
public ContentPublishControllerTestCase(
    string name,
    params ITestPart[] testParts)
    : base(name, testParts)
{
    // constructors will actually be empty - all the work is done by the base class - ZuraTDD.TestCase<,>
}

public async Task RunTestAsync()
{
    // to be completely precise - this method is inherited
}
```

## Setting up a test to run
It is generally advised to use the [`ZuraTest` attribute](https://github.com/jakubiszon/ZuraTDD/blob/main/Documentation/ZuraTest.md)
to set up tests but it is not always possible (e.g. when you use an unsupported `ZuraTest` framework).

If you need to run a test manually - create an instance of your type implementing the `ITestCase` and run its `RunTestAsync` method.

```csharp
using static MyTests.ContentPublishedEventHandlerTestCase;
using ZuraTDD;

namespace MyTests;

[TestClass]
public class ContentPublishedEventHandlerTests
{
	private readonly Content exampleContent = new Content(
		id: Guid.NewGuid(),
		title: "title",
		body: "body",
		topics: ["topic"],
		url: "http://exaple.com");

    [TestMethod]
    public async Task HandleContentPublish_Throws_When_CustomerRepositoryListByInterests_Throws()
    {
        var testCase = new ContentPublishedEventHandlerTestCase(
            name: "Throws when CustomerRepository.ListByInterests throws.",

            Receives.HandleContentPublish(exampleContent),

            When.CustomerRepository
                .ListByInterests()
                .Throws(new TestException()),

            Expect.ExceptionToBeThrown<TestException>()
        );

        await testCase.RunTestAsync();
    }
}
```
