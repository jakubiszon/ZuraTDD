# `ZuraTest` attribute
If you want to, you can write your test using the `ZuraTest` attribute.
It will create the test and the cove invoking the `TestCase` for you.
Your task will be to return the `ITestPart`-s that will be run as part of the test.
You place this attribute on methods and properties which return `ITestPart[]` or `IEnumerable<ITestPart>`.

Using this attribute requires you to specify the `TestCase` type as its generic param
as well as a name for the test to show in the test explorer.
```csharp
[ZuraTest<TestCaseClass>("Test name shown in the text explorer.")
ITestPart[] Method_TestParts => [ ... ]
```

This will only work if you use *Xunit* or *MSTest*. The other frameworks are not supported yet.


## Why is that useful?
It allows your tests to be expressed as sets of *conditions* and *expectations*
and treating them as data.

One test can work as a baseline defining a standard behavior.
Another can reuse it and only specify the deviations in behavior and expected results.


## Example
```csharp
using ZuraTDD;

[TestClass]
public partial class MyTests
{
	// Defines and tests the standard "happy path" for the
	// ContentPublishedEventHandler.Handle" method.
	[ZuraTest<ContentPublishedEventHandlerTestCase>(
		"Handle - sends email to customers when content is published.")]
	public ITestPart[] HandleStandardBehaviors => [
		Receives.Handle(exampleContent),

		When.CustomerRepository
			.ListByInterests(topics: null)
			.ReturnsInTask(new List<Customer> {exampleCustomer }),

		When.EmailSender
			.SendEmail()
			.Returns(Task.CompletedTask),

		Expect.EmailSender
			.SendEmail(to: new(s => s.Length > 0))
			.WasCalled(),

		Expect.EmailSender
			.SendEmailSync()
			.WasNotCalled()
	];

	// this test copes behaviors from the one above
	// then it only needs to specify the deviation in behavior
	// and the expectations of the test
	[ZuraTest<ContentPublishedEventHandlerTestCase>(
		"Throws when EmailSender.SendEmail throws.")]
	public ITestPart[] ThrowsTest1() => [
		Receives.Handle(exampleContent),

        // define throwing from the SendEmail method
		When.EmailSender
			.SendEmail()
			.Throws(new TestException()),

        // importing behaviors from another test is trivial
		..HandleStandardBehaviors
			.BehaviorsOnly(),

		Expect.ExceptionToBeThrown<TestException>()
	];
}
```
