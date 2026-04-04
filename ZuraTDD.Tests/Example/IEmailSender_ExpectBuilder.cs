using ZuraTDD;

namespace ZuraTDD.Tests.Example;

internal class IEmailSender_Expect : IEmailSender_ExpectBuilder
{
	public IEmailSender_Expect(
		MockedObject existingFake)
		: base(new ExpectedDependencyCallImmediateProcessor(existingFake))
	{
	}
}

internal class IEmailSender_ExpectStaticBuilder
	: IEmailSender_ExpectBuilder
{
	public IEmailSender_ExpectStaticBuilder(
		string serviceName)
		: base(new ExpectedDependencyCallNameProcessor(serviceName))
	{
	}
}

internal abstract class IEmailSender_ExpectBuilder
{
	private IExpectedDependencyCallProcessor processor;

	protected IEmailSender_ExpectBuilder(
		IExpectedDependencyCallProcessor processor)
	{
		this.processor = processor;
	}

	public ExpectedDependencyCallBuilder SendEmail(
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

	public ExpectedDependencyCallBuilder SendEmailSync(
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
