using Microsoft.CodeAnalysis;

namespace ZuraTDD.Generator.DataModel;

internal class TypeInfo
{
	/// <summary>
	/// Name of the type without the namespace.
	/// </summary>
	public string TypeName { get; }

	/// <summary>
	/// Gets the fully qualified name of the object, including its namespace or containing context.
	/// </summary>
	public string FullyQualifiedTypeName { get; }

	public TypeInfo(ITypeSymbol type)
	{
		TypeName = type.Name;
		FullyQualifiedTypeName = type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat.WithGlobalNamespaceStyle(SymbolDisplayGlobalNamespaceStyle.OmittedAsContaining));
	}
}
