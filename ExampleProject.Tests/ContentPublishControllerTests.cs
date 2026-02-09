using Microsoft.AspNetCore.Mvc;
using ZuraTDD;
using static ExampleProject.Tests.ContentPublishControllerTestCase;

namespace ExampleProject.Tests;

[TestClass]
public class ContentPublishControllerTests
{
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
