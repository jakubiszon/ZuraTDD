using System.Collections.Generic;
using System.Net.Sockets;
using Microsoft.CodeAnalysis;

namespace ZuraTDD.Generator.DataModel;

/// <summary>
/// Defines a dependency accepted as one constructor parameters by the test subject class.
/// </summary>
internal class DependencySpecification
{
	/// <summary>
	/// Constructor used when a type is passed as a constructor parameter of a test subject.
	/// </summary>
	public DependencySpecification(
		string outputNamespace,
		IParameterSymbol param)
	{
		OutputNamespace = outputNamespace;
		DependencyType = new TypeInfo(param.Type);
		DeclaringNamespace = param.Type.ContainingNamespace.ToDisplayString();
		DependencyPropertyName = param.Name.ToString().Capitalize();
		IsMockable = param.Type.TypeKind == TypeKind.Interface;

		MockedType = IsMockable
			? new MockedTypeSpecification(
				outputNamespace,
				param)
			: null as MockedTypeSpecification;
	}

	/// <summary>
	/// Name of the mocked type without the namespace.
	/// </summary>
	public TypeInfo DependencyType { get; }

	/// <summary>
	/// Specification of the mocked type. It will be null if the dependency is not mockable (i.e. it is not an interface).
	/// </summary>
	public MockedTypeSpecification? MockedType { get; }

	/// <summary>
	/// Namespace containing the mocked type.
	/// </summary>
	public string DeclaringNamespace { get; }

	/// <summary>
	/// Gets the namespace that will be used for generated output.
	/// </summary>
	public string OutputNamespace { get; }

	/// <summary>
	/// Name of the property in the TestSubjecyDependencies class generated for the test cases which reference the test subject.
	/// </summary>
	public string DependencyPropertyName { get; }

	/// <summary>
	/// Returns true if the dependency is an interface and can be mocked.
	/// </summary>
	public bool IsMockable { get; }
}
