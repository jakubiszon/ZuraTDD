using ExampleProject.Model;
using Microsoft.AspNetCore.Mvc;
using ZuraTDD;
using static ExampleProject.Tests.ContentPublishControllerTestCase;

namespace ExampleProject.Tests;

/// <summary>
/// This class demostrates using a generated TestCase class to test the <see cref="ContentPublishController">test subject class (ContentPublishController)</see>.
/// </summary>
[TestClass]
public class ContentPublishControllerTests
{
	/// <summary>
	/// The test method accepting TestCase instances from a generator method.
	/// Running the tests is done with calling the <see cref="TestCase.RunTestAsync"/> method.
	/// </summary>
	/// <param name="testCase">The test case instance to run.</param>
	[TestMethod]
	[DynamicData(nameof(PublishContent_TestCases))]
	public async Task PublishContent_Tests(TestCase testCase)
	{
		await testCase.RunTestAsync();
	}

	private static Content BuildExampleContent()
	{
		return new Content(
			id: Guid.NewGuid(),
			title: "Example Title",
			body: "Example body content.",
			topics: new List<string> { "Topic1", "Topic2" },
			url: "http://example.com/content"
		);
	}

	public static IEnumerable<object[]> PublishContent_TestCases()
	{
		yield return new ContentPublishControllerTestCase(
			name: "Returns BadRequest when content is null.",

			Receives.PublishContent(
				content: null),

			Expect.ResultMatching<IActionResult>(
				result => result is BadRequestObjectResult)
		);

		yield return new ContentPublishControllerTestCase(
			name: "Returns Ok when content is valid.",

			Receives.PublishContent(
				content: BuildExampleContent()),

			Expect.ResultMatching<IActionResult>(
				result => result is OkObjectResult)
		);

		yield return new ContentPublishControllerTestCase(
			name: "Throws ArgumentNullException when logger is null and there are errors in processing.",

			Receives.PublishContent(
				content: BuildExampleContent()),

			// the extension methods declared on ILogger<T> throw ArgumentNullException
			When.Logger.Is(null!),

			When.Handler
				.HandleContentPublish()
				.Throws(new Exception()),

			Expect.ExceptionToBeThrown<ArgumentNullException>()
		);

		yield return new ContentPublishControllerTestCase(
			name: "Calls logger.Log method when errors occur.",

			Receives.PublishContent(
				content: BuildExampleContent()),

			When.Handler
				.HandleContentPublish()
				.Throws(new Exception()),

			Expect.Logger
				.Log<GenericArgument.AnyType>()
				.WasCalled()
		);

		yield return new ContentPublishControllerTestCase(
			name: "Does not call logger.Log when no errors occur.",

			Receives.PublishContent(
				content: BuildExampleContent()),

			Expect.Logger
				.Log<GenericArgument.AnyType>()
				.WasNotCalled()
		);
	}
}
