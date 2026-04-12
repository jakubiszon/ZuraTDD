using ZuraTDD;
using static ExampleProject.Tests.ContentPublishedEventHandlerTestCase;

namespace ExampleProject.Tests;

[TestClass]
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

	public static IEnumerable<object[]> HandleMethodTestCases()
	{
		List<Customer> customerList = [exampleCustomer];

		string exampleMessageContent = $"Example message - {Guid.NewGuid()}";

		yield return new ContentPublishedEventHandlerTestCase(
			name: "Throws when CustomerRepository.ListByInterests throws.",

			Receives.HandleContentPublish(exampleContent),

			When.CustomerRepository
				.ListByInterests(topics: null)
				.Throws(new TestException()),

			Expect.ExceptionToBeThrown<TestException>()
		);

		yield return new ContentPublishedEventHandlerTestCase(
			name: "Throws when EmailSender.SendEmail throws.",

			Receives.HandleContentPublish(exampleContent),

			When.CustomerRepository
				.ListByInterests(topics: null)
				.Returns(Task.FromResult(customerList)),

			When.EmailSender
				.SendEmail()
				.Throws(new TestException()),

			Expect.ExceptionToBeThrown<TestException>()
		);

		yield return new ContentPublishedEventHandlerTestCase(
			name: "Sends email to customers when content is published.",

			Receives.HandleContentPublish(exampleContent),

			When.CustomerRepository
				.ListByInterests(topics: null)
				.ReturnsInTask(customerList),

			When.EmailSender
				.SendEmail()
				.Returns(Task.CompletedTask),

			//When.TemplateEngine
			//	.RenderTemplate()
			//	.Returns(Task.FromResult(exampleMessageContent)),

			Expect.EmailSender
				.SendEmail(to: new(s => s.Length > 0))
				.WasCalled(),

			Expect.EmailSender
				.SendEmailSync()
				.WasNotCalled()
		);

		yield return new ContentPublishedEventHandlerTestCase(
			name: "Sends email to customers when content is published.",

			Receives.HandleContentPublish(exampleContent),

			When.CustomerRepository
				.ListByInterests(topics: null)
				.Returns(Task.FromResult(customerList)),

			When.EmailSender
				.SendEmail()
				.Returns(Task.CompletedTask),

			When.EmailSender
				.SendEmailSync()
				.Throws(new Exception("Whoopsie!!!")),

			//When.TemplateEngine
			//	.RenderTemplate()
			//	.Returns(Task.FromResult(exampleMessageContent)),

			Expect.EmailSender
				.SendEmail(to: new(s => s.Length > 0))
				.WasCalled(),

			//Expect.EmailSender
			//	.SendEmail(
			//		to: "email@example.com",
			//		body: exampleMessageContent)
			//	.WasCalled(),

			Expect.EmailSender
				.SendEmailSync()
				.WasNotCalled()
		);
	}

	[TestMethod]
	[DynamicData(nameof(HandleMethodTestCases))]
	public async Task HandleTests(TestCase testCase)
	{
		await testCase.RunTestAsync();
	}

	/// <summary>
	/// Defines and tests the standard "happy path" for the HandleContentPublish method.
	/// </summary>
	[ZuraTest<ContentPublishedEventHandlerTestCase>(
		"HandleContentPublish - sends email to customers when content is published.")]
	public ITestPart[] HandleStandardBehaviors => [
		Receives.HandleContentPublish(exampleContent),

		When.CustomerRepository
			.ListByInterests(topics: null)
			.ReturnsInTask(new List<Customer> { exampleCustomer }),

		When.EmailSender
			.SendEmail()
			.Returns(Task.CompletedTask),

		Expect.EmailSender
			.SendEmail(to: exampleCustomer.Email)
			.WasCalled(),
	];

	[ZuraTest<ContentPublishedEventHandlerTestCase>(
		"HandleContentPublish - throws when CustomerRepository.ListByInterests throws.")]
	public ITestPart[] ThrowsTest_WhenListByInterestsThrows() => [
		Receives.HandleContentPublish(exampleContent),

		When.CustomerRepository
			.ListByInterests(topics: null)
			.Throws(new TestException()),

		..HandleStandardBehaviors
			.OnlyDependencySetup(),

		Expect.ExceptionToBeThrown<TestException>()
	];

	// this is a demonstration of reusing test parts defined in another method
	// the highlight of this test is that it only needs to specify the deviation from the standard behavior
	// and the expectation of the test
	[ZuraTest<ContentPublishedEventHandlerTestCase>(
		"HandleContentPublish - throws when EmailSender.SendEmail throws.")]
	public ITestPart[] ThrowsTest1() => [
		Receives.HandleContentPublish(exampleContent),

		When.EmailSender
			.SendEmail()
			.Throws(new TestException()),

		..HandleStandardBehaviors
			.OnlyDependencySetup(),

		Expect.ExceptionToBeThrown<TestException>()
	];
}
