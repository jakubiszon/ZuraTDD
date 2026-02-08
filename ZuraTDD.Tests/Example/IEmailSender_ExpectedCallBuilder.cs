using ZuraTDD;

namespace ZuraTDD.Tests.Example;

public class IEmailSender_StaticExpectedCallBuilder : IEmailSender_ExpectedCallBuilder
{
	public IEmailSender_StaticExpectedCallBuilder(string serviceName)
		: base(new ExpectedServiceCallOwnerName(serviceName))
	{
	}
}

public abstract class IEmailSender_ExpectedCallBuilder
{
	private readonly IExpectedServiceCallProcessor processor;

	public IEmailSender_ExpectedCallBuilder(
		IExpectedServiceCallProcessor processor)
	{
		this.processor = processor;
	}

	public ExpectedServiceCallBuilder SendEmail(
		ValueConstraint<string>? to = null,
		ValueConstraint<string>? subject = null,
		ValueConstraint<string>? body = null)
	{
		return new(
			IEmailSender_Methods.SendEmail,
			new ValueSetConstraint([
				to ?? new ValueConstraint<string>(),
				subject ?? new ValueConstraint<string>(),
				body ?? new ValueConstraint<string>(),
			]),
			this.processor);
	}

	public ExpectedServiceCallBuilder SendEmailSync(
		ValueConstraint<string>? to = null,
		ValueConstraint<string>? subject = null,
		ValueConstraint<string>? body = null)
	{
		return new(
			IEmailSender_Methods.SendEmailSync,
			new ValueSetConstraint([
				to ?? new ValueConstraint<string>(),
				subject ?? new ValueConstraint<string>(),
				body ?? new ValueConstraint<string>(),
			]),
			this.processor);
	}
}
