using System;
using System.Collections.Generic;

namespace ZuraTDD.Generator;

/// <summary>
/// An object used to collect source files and diagnostics to be emitted during source generation.
/// </summary>
internal class SourceFilesToCreate
{
	private readonly List<SourceFileOrDiagnostic> sourceGenerators = [];

	/// <summary>
	/// Adds a source file with the specified name and content generator function.
	/// </summary>
	/// <typeparam name="T">The type of the data to be provided to the content generator function.</typeparam>
	/// <param name="fileName">The name of the file to add. Cannot be null or empty.</param>
	/// <param name="generatorFunc">A function that generates the file content from the provided data. Cannot be null.</param>
	/// <param name="data">The data to be passed to the content generator function.</param>
	public void AddFile<T>(
		string fileName,
		Func<T, string> generatorFunc,
		T data)
	{
		sourceGenerators.Add(
			new SourceFileToGenerate(
				fileName,
				() => generatorFunc(data)));
	}

	// TODO:
	//public void AddDiagnostic(...)

	public void AddFiles(IEnumerable<SourceFileToGenerate> files)
	{
		foreach (var file in files)
		{
			sourceGenerators.Add(file);
		}
	}

	public void AddFiles(IEnumerable<SourceFileOrDiagnostic> files)
	{
		foreach (var file in files)
		{
			sourceGenerators.Add(file);
		}
	}

	public IEnumerable<SourceFileOrDiagnostic> GetItems()
		=> sourceGenerators;
}
