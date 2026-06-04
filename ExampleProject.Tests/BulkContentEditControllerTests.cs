using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using ZuraTDD;
using static ExampleProject.Tests.BulkContentEditControllerTestCase;

namespace ExampleProject.Tests;

[TestClass]
public partial class BulkContentEditControllerTests
{
	[ZuraTest<BulkContentEditControllerTestCase>("EditBulkContent - when no errors - commits transaction")]
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

	[ZuraTest<BulkContentEditControllerTestCase>("EditBulkContent - when UpdateMany throws - rolls back transaction")]
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
