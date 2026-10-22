using ExampleProject.Model;
using ZuraTDD;

namespace ExampleProject.Tests;

/// <summary>
/// Demonstrates how <see cref="PrepareTestClass"/> can be used to write tests.
/// </summary>
[TestClass]
[ZuraTestClass<ExampleProject.ContentPublishedEventHandler>]
public partial class ContentPublishedEventHandlerTests2
{
	[TestMethod]
	public async Task ExampleTest()
	{
		var customerList = new List<Customer>
		{
			new Customer(Guid.NewGuid(), "John Doe", "john@example.com")
		};

		var exampleContent = new Content(Guid.NewGuid(), "New Post", "Body", new List<string> { "topic1" }, "http://example.com");

		var (testObject, verify) = PrepareTestClass(
			When.CustomerRepository
				.ListByInterests(topics: null)
				.Returns(Task.FromResult(customerList)),

			When.EmailSender
				.SendEmail()
				.Returns(Task.CompletedTask),

			When.EmailSender
				.SendEmailSync()
				.Throws(new Exception("Whoopsie!!!"))
		);

		await testObject.HandleContentPublish(exampleContent);

		verify(
			Expect.EmailSender
				.SendEmail(to: new(s => s.Length > 0))
				.WasCalled(),

			Expect.EmailSender
				.SendEmailSync()
				.WasNotCalled()
		);
	}
}
