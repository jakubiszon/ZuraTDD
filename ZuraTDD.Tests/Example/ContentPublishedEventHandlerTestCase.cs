using ExampleProject;
using ZuraTDD;

namespace ZuraTDD.Tests.Example;

internal partial class ContentPublishedEventHandlerTestCase
	: TestCase<ContentPublishedEventHandler, ContentPublishedEventHandlerServices>
{
	/// <summary>
	/// Constructs a new <see cref="ContentPublishedEventHandler"/>.
	/// </summary>
	/// <param name="name"></param>
	/// <param name="testParts"></param>
	public ContentPublishedEventHandlerTestCase(
		string name,
		params ITestPart[] testParts)
		: base(name, testParts)
	{
	}

	/// <summary>
	/// Gets an instance of the class being tested.
	/// </summary>
	public override ExampleProject.ContentPublishedEventHandler GetTestSubject()
	{
		return new ExampleProject.ContentPublishedEventHandler(
			this.Services.CustomerRepository,
			this.Services.EmailSender,
			this.Services.TemplateEngine);
	}

	/// <summary>
	/// Contains method call specifications for the tested object.
	/// The received method should be the first parameter passed to the
	/// TestCase constructor.
	/// </summary>
	internal static class Receives
	{
		/// <summary>
		/// Defines a call to <see cref="ContentPublishedEventHandler.Handle(Content)"/> method.
		/// </summary>
		/// <returns></returns>
		public static TestedTaskCall Handle(Content? content = default)
		{
			#pragma warning disable CS8604 // Possible null reference argument.
			return new(
				obj => (obj as ContentPublishedEventHandler)!.Handle(content));
			#pragma warning restore CS8604 // Possible null reference argument.
		}
	}

	internal static class When
	{
		internal static ICustomerRepository_StaticBuilder CustomerRepository
			=> new ICustomerRepository_StaticBuilder("CustomerRepository");

		internal static IEmailSender_StaticBuilder EmailSender
			=> new IEmailSender_StaticBuilder("EmailSender");
	}

	internal static class Expect
	{
		public static ITestResultExpectation ExceptionToBeThrown<TException>()
			where TException : Exception
		{
			return new ExpectedException<TException>();
		}

		public static ITestResultExpectation ResultMatching<TResult>(Predicate<TResult> predicate)
		{
			return new ExpectedResultMatching<TResult>(predicate);
		}

		public static ITestResultExpectation ResultEqualTo<TResult>(TResult expectedValue)
		{
			return new ExpectedResultMatching<TResult>(value => value!.Equals(expectedValue));
		}

		internal static IEmailSender_StaticExpectedCallBuilder EmailSender
			=> new IEmailSender_StaticExpectedCallBuilder("EmailSender");

		internal static ICustomerRepository_StaticBuilder CustomerRepository
			=> new ICustomerRepository_StaticBuilder("CustomerRepository");
	}

	//public static ParameterConstraint<T> Matching<T>(Predicate<T> valueConstraint)
	//{
	//	return new ParameterConstraint<T>(valueConstraint);
	//}
}
