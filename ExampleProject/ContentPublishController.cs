using ExampleProject.Model;
using Microsoft.AspNetCore.Mvc;

namespace ExampleProject;

[ApiController]
public class ContentPublishController : ControllerBase
{
	private readonly IContentPublishedEventHandler _handler;
	private readonly ILogger<ContentPublishController> _logger;

	public ContentPublishController(
		IContentPublishedEventHandler handler,
		ILogger<ContentPublishController> logger)
	{
		_handler = handler;
		_logger = logger;
	}

	[HttpPost("api/content/publish")]
	public async Task<IActionResult> PublishContent([FromBody] Content content)
	{
		if (content == null)
		{
			return BadRequest("Content cannot be null");
		}

		try
		{
			await _handler.HandleContentPublish(content);
			return Ok(new { message = "Content published successfully" });
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "An error occured in {Method}", nameof(PublishContent));
			return StatusCode(500, "An error occurred while processing the request.");
		}
	}

	public int Add(int x, int y)
	{
		return x + y;
	}
}
