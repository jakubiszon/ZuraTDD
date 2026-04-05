using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;

namespace ZuraTDD.Generator.DataModel;

/// <summary>
/// Contains data defining dependencies of a test subject.
/// This data is passed to the template generating <see cref="ITestSubjectDependencies" /> implementations.
/// </summary>
internal class DependenciesClassSpecification
{
	/// <param name="outputNamespace">Namespace where the class will be generated.</param>
	/// <param name="testSubjectType">Compilation symbol of the type defining the test target.</param>
	public DependenciesClassSpecification(
		string outputNamespace,
		INamedTypeSymbol testSubjectType)
	{
		string testSubjectTypeName = testSubjectType.ToDisplayString();

		OutputNamespace = outputNamespace;
		DependenciesClassName = $"{testSubjectType.Name}Dependencies";
		TestSubjectClassName = testSubjectTypeName;
		TestSubjectFullyQualifiedName = testSubjectType.ToDisplayString(
			SymbolDisplayFormat.FullyQualifiedFormat);

		Dependencies = testSubjectType
			?.Constructors
			.FirstOrDefault()
			?.Parameters
			.Select(p => new DependencySpecification(outputNamespace, p))
			.ToList()
			?? [];
	}

	public string OutputNamespace { get; }

	public string DependenciesClassName { get; }

	public string TestSubjectClassName { get; }

	public string TestSubjectFullyQualifiedName { get; }

	public IReadOnlyList<DependencySpecification> Dependencies { get; }
}
