using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace ZuraTDD.Generator.DataModel;

/// <summary>
/// Defines a dependency accepted as one constructor parameters by the test subject class.
/// </summary>
internal class DependencySpecification
{
	/// <summary>
	/// Constructor used when a type is mocked using IMock&lt;T&gt; interface.
	/// </summary>
	/// <param name="outputNamespace">Namespace into which the code will be generated.</param>
	/// <param name="mockedType">Symbol representing the generic type declared in <see cref="IMock{TType}"/> interface.</param>
	public DependencySpecification(
		string outputNamespace,
		INamedTypeSymbol mockedType)
	{
		OutputNamespace = outputNamespace;
		MockedType = new TypeInfo(mockedType);
		DeclaringNamespace = mockedType.ContainingNamespace.ToDisplayString();
		IsInterface = mockedType.TypeKind == TypeKind.Interface;

		// TODO: use inheritance to apply this field only to services used by TestCase<T>
		//       to be completely correct - split into MockedObjectSpecification and DependencySpecification classes
		//       the two concepts only partly cover one another - we can mock without using test-subject dependencies
		//       we can also have a dependency which is not implemented by a mocked type.
		DependencyPropertyName = string.Empty;
		
		Methods = Functions.ExtractInterfaceMethods(mockedType);
	}

	/// <summary>
	/// Constructor used when a type is passed as a constructor parameter of a test subject.
	/// </summary>
	public DependencySpecification(
		string outputNamespace,
		IParameterSymbol param)
	{
		OutputNamespace = outputNamespace;
		MockedType = new TypeInfo(param.Type);
		DeclaringNamespace = param.Type.ContainingNamespace.ToDisplayString();
		DependencyPropertyName = param.Name.ToString().Capitalize();
		IsInterface = param.Type.TypeKind == TypeKind.Interface;
		
		Methods = Functions.ExtractInterfaceMethods(param.Type as INamedTypeSymbol);
	}

	/// <summary>
	/// Name of the mocked type without the namespace.
	/// </summary>
	public TypeInfo MockedType { get; }

	public string MockedFakeTypeName => $"{MockedType.TypeName}_Fake";

	public string MockedTypeMethodsTypeName => $"{MockedType.TypeName}_Methods";

	public string BuilderTypeName => $"{MockedType.TypeName}_Builder";

	public string ExpectTypeName => $"{MockedType.TypeName}_Expect";

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
	/// List of all public methods of the mocked type.
	/// </summary>
	public IReadOnlyList<MethodSpecification> Methods { get; }

	/// <summary>
	/// Returns true if the dependency is an interface and can be mocked.
	/// </summary>
	public bool IsInterface { get; }
}
