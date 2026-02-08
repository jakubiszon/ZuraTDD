namespace ExampleProject;

internal interface ICustomerRepository
{
	Task<List<Customer>> ListAll();

	Task<List<Customer>> ListByInterests(string topic);

	Task<List<Customer>> ListByInterests(List<string> topics);
}
