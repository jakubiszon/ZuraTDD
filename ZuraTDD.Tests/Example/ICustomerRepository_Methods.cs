using ExampleProject;
using System.Reflection;

namespace ZuraTDD.Tests.Example;

public static class ICustomerRepository_Methods
{
	public static MethodInfo ListAll = typeof(ICustomerRepository).GetMethod(
		nameof(ICustomerRepository.ListAll),
		[])!;

	public static MethodInfo ListByInterests__string = typeof(ICustomerRepository).GetMethod(
		nameof(ICustomerRepository.ListByInterests),
		[typeof(string)])!;

	public static MethodInfo ListByInterests__List_string = typeof(ICustomerRepository).GetMethod(
		nameof(ICustomerRepository.ListByInterests),
		[typeof(List<string>)])!;
}
