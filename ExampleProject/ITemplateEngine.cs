namespace ExampleProject;

internal interface ITemplateEngine
{
	Task<string> RenderTemplate(
		int templateId,
		Dictionary<string, string> parameters);
}
