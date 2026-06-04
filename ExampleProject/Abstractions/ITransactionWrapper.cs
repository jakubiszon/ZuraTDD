namespace ExampleProject.Abstractions;

public interface ITransactionWrapper
{
	void BeginTransaction();

	void CommitTransaction();

	void RollbackTransaction();
}
