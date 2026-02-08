using ZuraTDD.Exceptions;
using static ExampleProject.Tests.ContentPublishedEventHandlerTestCase;

namespace ExampleProject.Tests;

/// <summary>
/// End-to-end (using generated test case) verification of expectations
/// throwing exceptions when they are not satisfied by the ITestResult object.
/// </summary>
[TestClass]
public class ContentPublishedEventHandler_ExpectationFailTests
{
	private readonly Content exampleContent = new Content(
		id: Guid.NewGuid(),
		title: "title",
		body: "body",
		topics: ["topic"],
		url: "http://exaple.com");

	private readonly List<Customer> customerList = new List<Customer>
	{
		new(
			id: Guid.NewGuid(),
			name: "name",
			email: "email@example.com"),
	};

	[TestMethod]
	public async Task Expect_WasCalled__WhenNoMatchingCalls_Throws()
	{
		var testCase = new ContentPublishedEventHandlerTestCase(
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
				.Returns(Task.FromResult("whatever :D")),

			// expect a string shorter than zero to be used
			Expect.EmailSender
				.SendEmail(to: new(s => s.Length < 0))
				.WasCalled()
		);

		await Assert.ThrowsExactlyAsync<ExpectationFailed>(
			() => testCase.RunTestAsync());
	}

	[TestMethod]
	public async Task Expect_WasCalled__WhenLessMatchingCalls_Throws()
	{
		var testCase = new ContentPublishedEventHandlerTestCase(
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
				.Returns(Task.FromResult("whatever :D")),

			// expect multiple calls to SendEmail
			Expect.EmailSender
				.SendEmail()
				.WasCalled(999)
		);

		await Assert.ThrowsExactlyAsync<ExpectationFailed>(
			() => testCase.RunTestAsync());
	}
}
