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
	/// <param name="testSubjectType">Compilation symbol of the type defining the test target.</param>
	public DependenciesClassSpecification(
		INamedTypeSymbol testSubjectType)
	{
		string testSubjectTypeName = testSubjectType.ToDisplayString();

		OutputNamespace = $"ZuraTDD.Generated_{testSubjectType.ContainingNamespace.ToDisplayString().WithUnderscores()}";
		DependenciesClassName = $"{testSubjectType.Name}Dependencies";
		TestSubjectClassName = testSubjectTypeName;
		TestSubjectFullyQualifiedName = testSubjectType.ToDisplayString(
			SymbolDisplayFormat.FullyQualifiedFormat);

		Dependencies = testSubjectType
			?.Constructors
			.FirstOrDefault()
			?.Parameters
			.Select(p => new DependencySpecification(p))
			.ToList()
			?? [];
	}

	public string OutputNamespace { get; }

	public string OutputFileName => $"{OutputNamespace}.{DependenciesClassName}.generated.cs";

	/// <summary>
	/// Name of the class implementing <see cref="ITestSubjectDependencies" /> interface
	/// for the specified test subject type.
	/// </summary>
	/// <remarks>
	/// Only one class implementing the specific test subject dependencies will be generated
	/// even if there are multiple user-defined test-case classes or multiple ZuraTestClasses
	/// referencing the same test subject type.
	/// </remarks>
	public string DependenciesClassName { get; }

	public string DependenciesFullyQualifiedName => $"{OutputNamespace}.{DependenciesClassName}";

	public string TestSubjectClassName { get; }

	public string TestSubjectFullyQualifiedName { get; }

	public IReadOnlyList<DependencySpecification> Dependencies { get; }
}
