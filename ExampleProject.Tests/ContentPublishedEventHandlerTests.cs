using ZuraTDD;
using static ExampleProject.Tests.ContentPublishedEventHandlerTestCase;

namespace ExampleProject.Tests;

[TestClass]
public class ContentPublishedEventHandlerTests
{
	public static IEnumerable<object[]> HandleMethodTestCases()
	{
		var exampleContent = new Content(
			id: Guid.NewGuid(),
			title: "title",
			body: "body",
			topics: ["topic"],
			url: "http://exaple.com");

		var customerList = new List<Customer>
		{
			new(
				id: Guid.NewGuid(),
				name: "name",
				email: "email@example.com"),
		};

		string exampleMessageContent = $"Example message - {Guid.NewGuid()}";

		yield return new ContentPublishedEventHandlerTestCase(
			name: "Throws when CustomerRepository.ListByInterests throws.",

			Receives.Handle(exampleContent),

			When.CustomerRepository.ListByInterests(topics: null)
				.Throws(new TestException()),

			Expect.ExceptionToBeThrown<TestException>()
		);

		yield return new ContentPublishedEventHandlerTestCase(
			name: "Throws when EmailSender.SendEmail throws.",

			Receives.Handle(exampleContent),

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

			Receives.Handle(exampleContent),

			When.CustomerRepository
				.ListByInterests(topics: null)
				.Returns(Task.FromResult(customerList)),

			When.EmailSender
				.SendEmail()
				.Returns(Task.CompletedTask),

			When.TemplateEngine
				.RenderTemplate()
				.Returns(Task.FromResult(exampleMessageContent)),

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

		yield return new ContentPublishedEventHandlerTestCase(
			name: "Sends email to customers when content is published.",

			Receives.Handle(exampleContent),

			When.CustomerRepository
				.ListByInterests(topics: null)
				.Returns(Task.FromResult(customerList)),

			When.EmailSender
				.SendEmail()
				.Returns(Task.CompletedTask),

			When.EmailSender
				.SendEmailSync()
				.Throws(new Exception("Whoopsie!!!")),

			When.TemplateEngine
				.RenderTemplate()
				.Returns(Task.FromResult(exampleMessageContent)),

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
}
