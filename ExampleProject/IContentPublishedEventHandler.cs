namespace ExampleProject;

public interface IContentPublishedEventHandler
{
	Task Handle(Content content);
}
