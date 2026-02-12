namespace ExampleProject;

internal class ContentPublishedEventHandler : IContentPublishedEventHandler
{
	private readonly ICustomerRepository customerRepository;
	private readonly IEmailSender emailSender;
	//private readonly ITemplateEngine templateEngine;

	public ContentPublishedEventHandler(
		ICustomerRepository customerRepository,
		IEmailSender emailSender)
		//ITemplateEngine templateEngine)
	{
		this.customerRepository = customerRepository;
		this.emailSender = emailSender;
		//this.templateEngine = templateEngine;
	}

	public async Task Handle(Content content)
	{
		var interestedCustomers = await customerRepository.ListByInterests(content.Topics);
		foreach (var customer in interestedCustomers)
		{
			var subject = $"New content published: {content.Title}";
			var body =
				$"""
				Dear {customer.Name},
				We have published new content that might interest you:
				{content.Url}

				Best regards,
				Your Team
				""";

			await emailSender.SendEmail(customer.Email, subject, body);
		}
	}
}
