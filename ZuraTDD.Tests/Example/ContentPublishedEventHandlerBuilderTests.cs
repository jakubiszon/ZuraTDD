using System;
using System.Collections.Generic;
using System.Text;
using ExampleProject;

namespace ZuraTDD.Tests.Example;

[TestClass]
public class ContentPublishedEventHandlerBuilderTests
{
	private static readonly Content exampleContent = new(
		id: Guid.NewGuid(),
		title: "title",
		body: "body",
		topics: ["topic"],
		url: "http://exaple.com");

	private static readonly List<Customer> customerList = [
		new(
			id: Guid.NewGuid(),
			name: "name",
			email: "email@example.com"),
	];


	[TestMethod]
	public void BuildInstance_ReturnsAnObject()
	{
		var builder = new ContentPublishedEventHandlerBuilder();
		var testSubject = builder.BuildInstance();
		Assert.IsNotNull(testSubject);
	}

	[TestMethod]
	public void BuildeExpect_ReturnsAnObjectt()
	{
		var builder = new ContentPublishedEventHandlerBuilder();
		var expect = builder.BuildExpect();
		Assert.IsNotNull(expect);
	}

	[TestMethod]
	public void ExpectingCalls_WhenNoCallsWereMade_Throws()
	{
		var builder = new ContentPublishedEventHandlerBuilder();
		var expect = builder.BuildExpect();

		Assert.Throws<Exception>(() => expect.EmailSender
			.SendEmailSync()
			.WasCalled());
	}

	[TestMethod]
	public async Task Handle_Throws_WhenCustomerRepositoryThrows()
	{
		var builder = new ContentPublishedEventHandlerBuilder();
		builder.CustomerRepository
				.ListByInterests(topics: null)
				.Throws(new TestException());

		var testSubject = builder.BuildInstance();

		await Assert.ThrowsAsync<TestException>(() => testSubject.Handle(exampleContent));

		var expect = builder.BuildExpect();

		expect.CustomerRepository
			.ListByInterests(topics: null)
			.WasCalled(1);

		expect.EmailSender
			.SendEmail()
			.WasNotCalled();
	}

	[TestMethod]
	public async Task Handle_Throws_WhenEmailSenderThrows()
	{
		var builder = new ContentPublishedEventHandlerBuilder();
		builder.CustomerRepository
			.ListByInterests(topics: null)
			.Returns(Task.FromResult(customerList));

		builder.EmailSender
			.SendEmail()
			.Throws(new TestException());

		var testSubject = builder.BuildInstance();

		// note that the only thing that could throw this exception if the SendEmail method
		await Assert.ThrowsAsync<TestException>(() => testSubject.Handle(exampleContent));

		var expect = builder.BuildExpect();

		expect.CustomerRepository
			.ListByInterests(topics: null)
			.WasCalled(1);

		expect.EmailSender
			.SendEmail()
			.WasCalled(1);
	}
}
