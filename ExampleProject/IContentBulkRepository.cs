using ExampleProject.Abstractions;

namespace ExampleProject;

public interface IContentBulkRepository : ITransactionWrapper
{
	Task UpdateMany();
}
