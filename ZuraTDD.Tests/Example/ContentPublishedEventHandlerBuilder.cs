using ExampleProject;

namespace ZuraTDD.Tests.Example;

/// <summary>
/// A stateful object used to construct a single instance of ContentPublishedEventHandler
/// and ContentPublishedEventHandler_Expect.
/// </summary>
internal class ContentPublishedEventHandlerBuilder
	: ITestSubjectBuilder<ContentPublishedEventHandler>
{
	private readonly Lazy<IEmailSender_Fake> emailSender_Fake;
	private readonly Lazy<ICustomerRepository_Fake> customerRepository_Fake;
	private readonly Lazy<ContentPublishedEventHandler> instance;

	public IEmailSender_Builder EmailSender { get; }

	public ICustomerRepository_Builder CustomerRepository { get; }

	public ContentPublishedEventHandlerBuilder()
	{
		this.CustomerRepository = new();
		customerRepository_Fake = new(() => this.CustomerRepository.BuildInstance());

		this.EmailSender = new();
		emailSender_Fake = new(() => this.EmailSender.BuildInstance());

		this.instance = new(() => new ExampleProject.ContentPublishedEventHandler(
			customerRepository_Fake.Value,
			emailSender_Fake.Value/*,
			this.Services.TemplateEngine*/));
	}

	/// <summary>
	/// Builds and returns an instance of the ContentPublishedEventHandler.
	/// Multiple calls to this method will return the same object.
	/// </summary>
	public ContentPublishedEventHandler BuildInstance()
	{
		return instance.Value;
	}

	/// <summary>
	/// Builds and returns an instance of ContentPublishedEventHandler_Expect.
	/// Multiple calls to this method will return new objects referencing the same data.
	/// </summary>
	public ContentPublishedEventHandler_Expect BuildExpect()
	{
		return new(
			customerRepository_Fake.Value,
			emailSender_Fake.Value);
	}
}
