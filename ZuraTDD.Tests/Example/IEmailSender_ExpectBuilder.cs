using ZuraTDD;

namespace ZuraTDD.Tests.Example;

internal class IEmailSender_Expect : IEmailSender_ExpectBuilder
{
	public IEmailSender_Expect(
		FakeService existingFake)
		: base(new ExpectedServiceCallImmediateProcessor(existingFake))
	{
	}
}

internal abstract class IEmailSender_ExpectBuilder
{
	private IExpectedServiceCallProcessor processor;

	protected IEmailSender_ExpectBuilder(
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
