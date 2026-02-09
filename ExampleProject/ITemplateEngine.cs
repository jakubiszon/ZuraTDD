namespace ExampleProject;

public interface ITemplateEngine
{
	Task<string> RenderTemplate(
		int templateId,
		Dictionary<string, string> parameters);
}
