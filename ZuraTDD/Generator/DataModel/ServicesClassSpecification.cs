using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;

namespace ZuraTDD.Generator.DataModel;

/// <summary>
/// Contains data passed to the "service" template.
/// </summary>
internal class ServicesClassSpecification
{
	/// <param name="outputNamespace">Namespace where the services class will be generated.</param>
	/// <param name="testSubjectType">Compilation symbol of the type defining the test target.</param>
	public ServicesClassSpecification(
		string outputNamespace,
		INamedTypeSymbol testSubjectType)
	{
		string testSubjectTypeName = testSubjectType.ToDisplayString();

		OutputNamespace = outputNamespace;
		ServicesClassName = $"{testSubjectType.Name}Services";
		TestSubjectClassName = testSubjectTypeName;

		Services = testSubjectType
			?.Constructors
			.FirstOrDefault()
			?.Parameters
			.Select(p => new ServiceSpecification(outputNamespace, p))
			.ToList()
			?? [];
	}

	public string OutputNamespace { get; } = string.Empty;

	public string ServicesClassName { get; } = string.Empty;

	public string TestSubjectClassName { get; } = string.Empty;

	public IReadOnlyList<ServiceSpecification> Services { get; }
}
