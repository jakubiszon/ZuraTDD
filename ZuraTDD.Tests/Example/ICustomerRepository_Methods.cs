using ExampleProject;

namespace ZuraTDD.Tests.Example;

public static class ICustomerRepository_Methods
{
	public static ZuraMethodInfo ListAll = typeof(ICustomerRepository).GetMethod(
		nameof(ICustomerRepository.ListAll),
		[])!;

	public static ZuraMethodInfo ListByInterests__string = typeof(ICustomerRepository).GetMethod(
		nameof(ICustomerRepository.ListByInterests),
		[typeof(string)])!;

	public static ZuraMethodInfo ListByInterests__List_string = typeof(ICustomerRepository).GetMethod(
		nameof(ICustomerRepository.ListByInterests),
		[typeof(List<string>)])!;
}
