namespace ExampleProject;

public interface IContentPublishedEventHandler
{
	Task HandleContentPublish(Content content);
}
