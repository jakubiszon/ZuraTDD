using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace ZuraTDD.Generator.DataModel;

internal class TypeInfo : IUseGenericTypeParameters
{
	/// <summary>
	/// Name of the type without the namespace.
	/// </summary>
	public string TypeName { get; }

	/// <summary>
	/// The namespace inside which the type was declared.
	/// </summary>
	public string DeclaringNamespace { get; }

	/// <summary>
	/// Gets the fully qualified name of the object, including its namespace or containing context.
	/// This version also contains the applied generic type param values.
	/// </summary>
	public string FullyQualifiedTypeName { get; }

	/// <summary>
	/// Gets the fully qualified name of the object, including its namespace or containing context.
	/// This version contains the generic type param names, not the applied values.
	/// </summary>
	public string FullyQualifiedGenericTypeName { get; }

	public IReadOnlyCollection<GenericTypeParamSpecification> GenericTypeParameters { get; }

	/// <summary>
	/// Constructor using INamedTypeSymbol.
	/// Using this constructor is crucial when generic type parameter information is needed.
	/// </summary>
	public TypeInfo(INamedTypeSymbol type)
	{
		TypeName = type.Name;
		DeclaringNamespace = type.ContainingNamespace.ToDisplayString();
		FullyQualifiedTypeName = type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat.WithGlobalNamespaceStyle(SymbolDisplayGlobalNamespaceStyle.OmittedAsContaining));

		FullyQualifiedGenericTypeName = type.IsGenericType && !type.IsUnboundGenericType
			? type.OriginalDefinition.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat.WithGlobalNamespaceStyle(SymbolDisplayGlobalNamespaceStyle.OmittedAsContaining))
			: FullyQualifiedTypeName;

		GenericTypeParameters = type.TypeParameters
			.Select(t => new GenericTypeParamSpecification(t))
			.ToList() ?? new List<GenericTypeParamSpecification>();
	}

	/// <summary>
	/// Constructor using IParameterSymbol.
	/// This constructor should only be used as a fallback when finding INamedTypeSymbol did not work
	/// or when generic type parameter information is not needed.
	/// </summary>
	public TypeInfo(IParameterSymbol parameter)
	{
		TypeName = parameter.Type.Name;
		DeclaringNamespace = parameter.Type.ContainingNamespace.ToDisplayString();
		FullyQualifiedTypeName = parameter.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat.WithGlobalNamespaceStyle(SymbolDisplayGlobalNamespaceStyle.OmittedAsContaining));
		FullyQualifiedGenericTypeName = FullyQualifiedTypeName;
		GenericTypeParameters = [];
	}
}
