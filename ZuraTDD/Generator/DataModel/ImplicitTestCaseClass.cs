using Microsoft.CodeAnalysis;

namespace ZuraTDD.Generator.DataModel;

internal class ImplicitTestCaseClass
{
	public string Name { get; }

	public string Namespace { get; }

	public string OutputFileName => $"{Namespace}.{Name}.generated.cs";

	public ImplicitTestCaseClass(ITypeSymbol testSubjectType)
	{
		Name = $"{testSubjectType.Name}TestCase";
		Namespace = $"ZuraTDD.Generated_{testSubjectType.ContainingNamespace.ToDisplayString().WithUnderscores()}";
	}
}
