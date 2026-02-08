using ZuraTDD;

namespace ZuraTDD.Tests.Example;

/// <summary>
/// Services used by the test cases for <see cref="ExampleProject.ContentPublishedEventHandler" />.
/// </summary>
public class ContentPublishedEventHandlerServices : ITestSubjectServices
{
	private Dictionary<string, FakeService> services = new();

	/// <summary>
	/// Substitute for <see cref="ExampleProject.ICustomerRepository" />.
	/// </summary>
	internal ExampleProject.ICustomerRepository CustomerRepository { get; }

	/// <summary>
	/// Substitute for <see cref="ExampleProject.IEmailSender" />.
	/// </summary>
	internal ExampleProject.IEmailSender EmailSender { get; }

	internal ExampleProject.ITemplateEngine TemplateEngine { get; }

	public FakeService this[string serviceName] => services[serviceName];

	public ContentPublishedEventHandlerServices()
	{
		this.CustomerRepository = new ICustomerRepository_Fake();
		this.EmailSender = new IEmailSender_Fake();
		this.TemplateEngine = null!; //new TemplateEngine_Fake();

		services["CustomerRepository"] = (FakeService)this.CustomerRepository;
		services["EmailSender"] = (FakeService)this.EmailSender;
	}
}
