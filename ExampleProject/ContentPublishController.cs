using Microsoft.AspNetCore.Mvc;

namespace ExampleProject;

[ApiController]
public class ContentPublishController : ControllerBase
{
	private readonly IContentPublishedEventHandler _handler;

	public ContentPublishController(IContentPublishedEventHandler handler)
	{
		_handler = handler;
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
			await _handler.Handle(content);
			return Ok(new { message = "Content published successfully" });
		}
		catch (Exception ex)
		{
			return StatusCode(500, new { error = ex.Message });
		}
	}
}

