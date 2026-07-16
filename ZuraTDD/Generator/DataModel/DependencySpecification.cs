using System;
using System.Collections.Generic;
using System.Linq;
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
		IParameterSymbol param)
	{
		var namedType = param.Type as INamedTypeSymbol
			?? param.Type.OriginalDefinition as INamedTypeSymbol;

		DependencyType = namedType != null
			? new TypeInfo(namedType)
			: new TypeInfo(param);

		AppliedTypeParamNames = (param.Type as INamedTypeSymbol)
			?.TypeArguments
			.Select(t => t.ToDisplayString())
			.ToArray()
			?? Array.Empty<string>();

		DeclaringNamespace = param.Type.ContainingNamespace.ToDisplayString();
		DependencyPropertyName = param.Name.ToString().Capitalize();
		IsMockable = param.Type.TypeKind == TypeKind.Interface;

		MockedType = IsMockable
			? new MockedTypeSpecification(param)
			: null;
	}

	/// <summary>
	/// Information about the mocked type in its most abstract form.
	/// No applied generic type parameters are included in this type information.
	/// </summary>
	public TypeInfo DependencyType { get; }

	public IReadOnlyCollection<string> AppliedTypeParamNames { get; }

	/// <summary>
	/// Specification of the mocked type. It will be null if the dependency is not mockable (i.e. it is not an interface).
	/// </summary>
	public MockedTypeSpecification? MockedType { get; }

	/// <summary>
	/// Namespace containing the mocked type.
	/// </summary>
	public string DeclaringNamespace { get; }

	/// <summary>
	/// Gets the namespace that will be used by the generated classes.
	/// </summary>
	public string OutputNamespace => $"ZuraTDD.Generated_{DependencyType.DeclaringNamespace.WithUnderscores()}";

	/// <summary>
	/// Gets the prefix for file names which will contain generated code
	/// e.g. "NamedInstanceBuilder"
	/// </summary>
	public string OutputFilePrefix => MockedType?.OutputFilePrefix
		?? $"{OutputNamespace}.{DependencyType.TypeName}";

	/// <summary>
	/// Name of the property in the TestSubjecyDependencies class generated for the test cases which reference the test subject.
	/// </summary>
	public string DependencyPropertyName { get; }

	/// <summary>
	/// Returns true if the dependency is an interface and can be mocked.
	/// </summary>
	public bool IsMockable { get; }
}
