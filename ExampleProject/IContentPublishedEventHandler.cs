using ExampleProject.Model;

namespace ExampleProject;

public interface IContentPublishedEventHandler
{
	Task HandleContentPublish(Content content);
}
