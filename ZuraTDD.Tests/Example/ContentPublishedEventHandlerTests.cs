using ExampleProject;
using static ZuraTDD.Tests.Example.ContentPublishedEventHandlerTestCase;

namespace ZuraTDD.Tests.Example;

[TestClass]
public partial class ContentPublishedEventHandlerTests
{
	//[TestCases]
	internal static IEnumerable<ContentPublishedEventHandlerTestCase> Handle_TestCases()
	{
		var exampleContent = new Content(
			id: Guid.NewGuid(),
			title: "title",
			body: "body",
			topics: ["topic"],
			url: "http://exaple.com");

		yield return new ContentPublishedEventHandlerTestCase(
			name: "Throws when CustomerRepository.ListByInterests throws.",

			Receives.Handle(exampleContent),

			When.CustomerRepository.ListByInterests(topics: null)
				.Throws(new TestException()),

			Expect.ExceptionToBeThrown<TestException>()
		);

		yield return new ContentPublishedEventHandlerTestCase(
			name: "Sends email to customers when content is published.",

			Receives.Handle(exampleContent),

			When.CustomerRepository.ListByInterests(topics: null)
				.Returns(
					Task.FromResult<List<Customer>>(
						[new Customer(Guid.NewGuid(), "name", "email@example.com")])),

			When.EmailSender.SendEmail()
				.Returns(Task.CompletedTask),

			When.EmailSender.SendEmailSync()
				.Throws(new Exception("Whoopsie!!!")),

			Expect.EmailSender.SendEmail(
				to: new(s => s.Length > 0))
				.WasCalled(),

			Expect.EmailSender.SendEmail(
				to: "email@example.com")
				.WasCalled(),

			Expect.EmailSender.SendEmailSync()
				.WasNotCalled()
		);
	}
}
