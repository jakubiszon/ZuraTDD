# Zura TDD `TestCase` objects

You can use ZuraTDD to create `TestCase` classes - if you need them outside classes marked as `ZuraTestClass`.
You can do so by declaring a class as implementing `ITestCase<TSubject>`.
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

What you get is a class containing:
- A static `Receives` builder - which allows specifying the tested method and how it is invoked.
  In the example above, it will expose:
  - `Receives.HandleContentPublish`
- `When` builder (also static) - which allows setting up dependenecies and their behaviors.
  Every constructor parameter will have its own builder inside the `When`. In the example above, you will get:
  - `When.CustomerRepository` - it will expose methods of `ICustomerRepository` and allow you to set up their behaviors.
  - `When.EmailSender` - it will expose methods of `IEmailSender` and allow you to set up their behaviors.
- `Expect` static builder - it allows you to set up expectations for interactions with dependencies as well as for the value returned from the tested method.
  Every interface which is a constructor parameter will have its own builder inside the `Expect`.
  - `Expect.CustomerRepository` - it will expose methods of `ICustomerRepository` and allow you to set up expectations for their invocations.
  - `Expect.EmailSender` - it will expose methods of `IEmailSender` to allow you setting up expectations for their invocations.
  - `Expect.ResultMatching<TResult>(Predicate<TResult> predicate)` - allows you to specify a predicate to match against the value returned from the tested method.
  - `Expect.ResultEqualTo<TResult>(TResult expectedValue)` - allows you to specify equality match expectation for the tested method result.
- A `public` constructor accepting `string name` and `params ITestPart[] testParts` parameters.
- A `public async Task RunTestAsync()` method.

Note: `RunTestAsync` is always `async`. There is no synchronous version of this method - it is always `async` even if the tested methos is not.

## Setting up a test to run

If you need to run a test manually - create an instance of your test-case and run its `RunTestAsync` method.

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
