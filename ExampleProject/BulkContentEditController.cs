using Microsoft.AspNetCore.Mvc;

namespace ExampleProject;

[ApiController]
public class BulkContentEditController : ControllerBase
{
	private readonly IContentBulkRepository contentBulkRepository;

	public BulkContentEditController(IContentBulkRepository contentBulkRepository)
	{
		this.contentBulkRepository = contentBulkRepository;
	}

	[HttpPost("api/content/edit-bulk")]
	public async Task<IActionResult> EditBulkContent()
	{
		try
		{
			contentBulkRepository.BeginTransaction();

			await contentBulkRepository.UpdateMany();
			await contentBulkRepository.UpdateMany();

			contentBulkRepository.CommitTransaction();

			return Ok();
		}
		catch
		{
			contentBulkRepository.RollbackTransaction();
			return StatusCode(500, "An error occurred while processing the request.");
		}
	}
}
