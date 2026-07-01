using Microsoft.CodeAnalysis;

namespace ZuraTDD.Generator.DataModel;

internal class ParameterSpecification
{
	/// <summary>
	/// Format used to get the type name to use in <see langword="typeof" /> expressions in generated code.
	/// </summary>
	private static readonly SymbolDisplayFormat TypeOfFormat = new(
		typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces,
		genericsOptions: SymbolDisplayGenericsOptions.IncludeTypeParameters,
		miscellaneousOptions: SymbolDisplayMiscellaneousOptions.None);

	public string Type { get; }

	/// <summary>
	/// Specifies whether the type of the parameter is a reference type.
	/// </summary>
	public bool IsReferenceType { get; }

	public string Name { get; }

	/// <summary>
	/// Type name to use in <see langword="typeof" /> expressions for this parameter.
	/// It may differ from <see cref="Type"/> for cases like nullable reference types.
	/// </summary>
	public string TypeOfOperatorTypeName { get; }

	public ParameterSpecification(IParameterSymbol parameterSymbol)
	{
		Type = parameterSymbol.Type.ToDisplayString();
		Name = parameterSymbol.Name;
		TypeOfOperatorTypeName = parameterSymbol.Type.ToDisplayString(TypeOfFormat);
		IsReferenceType = parameterSymbol.Type.IsReferenceType;
	}
}
