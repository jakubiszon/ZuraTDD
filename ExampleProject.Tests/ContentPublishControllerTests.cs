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

	public static IEnumerable<object[]> PublishContent_TestCases()
	{
		yield return new ContentPublishControllerTestCase(
			name: "Returns BadRequest when content is null.",

			Receives.PublishContent(
				content: null),

			Expect.ResultMatching<IActionResult>(
				result => result is BadRequestObjectResult)
		);
	}
}
