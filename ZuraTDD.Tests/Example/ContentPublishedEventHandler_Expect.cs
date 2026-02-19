namespace ZuraTDD.Tests.Example;

internal class ContentPublishedEventHandler_Expect
{
	public IEmailSender_Expect EmailSender { get; }

	public ICustomerRepository_Expect CustomerRepository { get; }

	public ContentPublishedEventHandler_Expect(
		ICustomerRepository_Fake customerRepository,
		IEmailSender_Fake emailSender)
	{
		EmailSender = new(emailSender);
		CustomerRepository = new(customerRepository);
	}
}
