using Microsoft.AspNetCore.Mvc;
using ZuraTDD;

namespace ExampleProject.Tests;

[TestClass]
[ZuraTestClass<BulkContentEditController>]
public partial class BulkContentEditControllerTests
{
	[ZuraTest("EditBulkContent - when no errors - commits transaction")]
	public ITestPart[] EditBulkContent_HappyPathSteps => [
		Receives.EditBulkContent(),

		Expect.ContentBulkRepository
			.UpdateMany()
			.WasCalled(),

		Expect.ContentBulkRepository
			.CommitTransaction()
			.WasCalled(1),

		Expect.ResultMatching<IActionResult>(result => result is OkResult),
	];

	[ZuraTest("EditBulkContent - when UpdateMany throws - rolls back transaction")]
	public ITestPart[] EditBulkContent_UpdateManyThrows => [
		Receives.EditBulkContent(),

		When.ContentBulkRepository
			.UpdateMany()
			.Throws(new Exception("Database error")),

		Expect.ContentBulkRepository
			.RollbackTransaction()
			.WasCalled(1),

		Expect.ResultMatching<ObjectResult>(result => result.StatusCode == 500),
	];
}
