namespace ExampleProject;

public class Customer
{
	public Guid Id { get; }

	public string Name { get; }

	public string Email { get; }

	public Customer(Guid id, string name, string email)
	{
		Id = id;
		Name = name;
		Email = email;
	}
}
