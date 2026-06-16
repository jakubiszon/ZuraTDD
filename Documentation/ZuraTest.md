# `ZuraTest` attribute
It is recommended to write your test using the `ZuraTest` attribute.
It will create the test and the code invoking the `TestCase` for you.
Your task will be to return the `ITestPart`-s that will be run as part of the test.
You place this attribute on either methods or properties which return `ITestPart[]` or `IEnumerable<ITestPart>`.

Using this attribute requires you to specify the `TestCase` type as its generic param
as well as a name for the test to show in the test explorer.
The class which declares methods or properties with this attribute must be marked as `partial`.
If you are using *MsTest* - the class must also be marked with the `[TestClass]` attribute

```csharp
using ZuraTDD;
using static TestCaseClass;

[TestClass] // required for MSTest
public partial class MyTestCaseTests
{
    [ZuraTest<TestCaseClass>("Test name shown in the text explorer.")
    ITestPart[] Method_TestParts => [
        // declare test parts here
        Receives...
        When...
        Expect...
    ];
}
```


## Why is that useful?
It allows your tests to be expressed as sets of *conditions* and *expectations*
and treating them as data.

One test can work as a baseline defining a standard behavior.
Another can reuse it and only specify the deviations in behavior and expected results.


## Example
```csharp
using ZuraTDD;
using static ContentPublishedEventHandlerTestCase;

// required to easily access the builders for the ContentPublishedEventHandlerTestCase
using static MyTestNamespace.ContentPublishedEventHandlerTestCase

namespace MyTestNamespace;

[TestClass]
public partial class MyTests
{
	// Defines and tests the standard "happy path" for the
	// ContentPublishedEventHandler.Handle method.
	[ZuraTest<ContentPublishedEventHandlerTestCase>(
		"Handle - sends email to customers when content is published.")]
	public ITestPart[] HandleStandardBehaviors => [
		Receives.Handle(exampleContent),

		When.CustomerRepository
			.ListByInterests(topics: null)
			.ReturnsInTask(new List<Customer> { exampleCustomer }),

		When.EmailSender
			.SendEmail()
			.Returns(Task.CompletedTask),

		Expect.EmailSender
			.SendEmail(to: new(s => s.Length > 0))
			.WasCalled(),
	];

	// this test copies behaviors from the one above
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

        // importing dependency setup and behaviors from another test is trivial
		..HandleStandardBehaviors
			.OnlyDependencySetup(),

		Expect.ExceptionToBeThrown<TestException>()
	];
}
```

## Limitations

At the moment this attribute is only supported for *Xunit* and *MSTest*.

When you are using other testing frameworks - you can still use the builders created for your `ITestCase` marked classes but you need to [create a test manually](https://github.com/jakubiszon/ZuraTDD/blob/main/Documentation/TestCases.md).
