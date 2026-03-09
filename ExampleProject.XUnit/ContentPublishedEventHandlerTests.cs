using ZuraTDD;
using static ExampleProject.XUnit.ContentPublishedEventHandlerTestCase;

namespace ExampleProject.XUnit;

public partial class ContentPublishedEventHandlerTests
{
	private static readonly Content exampleContent = new(
		id: Guid.NewGuid(),
		title: "title",
		body: "body",
		topics: ["topic"],
		url: "http://exaple.com");

	private static Customer exampleCustomer = new(
		id: Guid.NewGuid(),
		name: "name",
		email: "email@example.com");

	/// <summary>
	/// Defines and tests the standard "happy path" for the
	/// <see cref="ContentPublishedEventHandler.Handle" />
	/// </summary>
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

	[ZuraTest<ContentPublishedEventHandlerTestCase>(
		"Throws when CustomerRepository.ListByInterests throws.")]
	public ITestPart[] ThrowsTest_WhenListByInterestsThrows() => [
		Receives.Handle(exampleContent),

		When.CustomerRepository
			.ListByInterests(topics: null)
			.Throws(new TestException()),

		..HandleStandardBehaviors
			.BehaviorsOnly(),

		Expect.ExceptionToBeThrown<TestException>()
	];

	// this is a demonstration of reusing test parts defined in another method
	// the highlight of this test is that it only needs to specify the deviation from the standard behavior
	// and the expectation of the test
	[ZuraTest<ContentPublishedEventHandlerTestCase>(
		"Throws when EmailSender.SendEmail throws.")]
	public ITestPart[] ThrowsTest1() => [
		Receives.Handle(exampleContent),

		When.EmailSender
			.SendEmail()
			.Throws(new TestException()),

		..HandleStandardBehaviors
			.BehaviorsOnly(),

		Expect.ExceptionToBeThrown<TestException>()
	];
}
