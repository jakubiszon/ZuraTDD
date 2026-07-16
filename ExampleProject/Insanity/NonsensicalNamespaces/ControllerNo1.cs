namespace ExampleProject.Insanity.NonsensicalNamespaces.Foo;

public class ControllerInsideWeirdNamespace
{
	private readonly IExampleRepository exampleRepository;
	private readonly Baz.IExampleRepository nestedNamespaceRepository;

	public ControllerInsideWeirdNamespace(
		IExampleRepository exampleRepository,
		Baz.IExampleRepository nestedNamespaceRepository)
	{
		this.exampleRepository = exampleRepository;
		this.nestedNamespaceRepository = nestedNamespaceRepository;
	}

	public bool DependenciesReturnSameData()
	{
		var dataFromExampleRepository = exampleRepository.GetData1();
		var dataFromNestedNamespaceRepository = nestedNamespaceRepository.GetData2();
		return dataFromExampleRepository == dataFromNestedNamespaceRepository;
	}
}
