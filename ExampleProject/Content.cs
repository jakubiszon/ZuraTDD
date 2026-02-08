namespace ExampleProject;

internal class Content
{
	public Guid Id { get; }

	public string Title { get; }

	public string Body { get; }

	public List<string> Topics { get; }

	public string Url { get; }

	public Content(Guid id, string title, string body, List<string> topics, string url)
	{
		Id = id;
		Title = title;
		Body = body;
		Topics = topics;
		Url = url;
	}
}
