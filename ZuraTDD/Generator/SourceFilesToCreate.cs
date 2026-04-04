using System;
using System.Collections.Generic;

namespace ZuraTDD.Generator;

/// <summary>
/// An object used to collect unique source files to be generated.
/// </summary>
internal class SourceFilesToCreate
{
	private readonly Dictionary<string, SourceFileToGenerate> sourceGenerators = [];

	/// <summary>
	/// Adds a source file with the specified name and content generator function,
	/// unless a file with the same name already exists.
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
		if(sourceGenerators.ContainsKey(fileName))
			return;

		sourceGenerators.Add(
			fileName,
			new SourceFileToGenerate(
				fileName,
				() => generatorFunc(data)));
	}

	public void AddFiles(IEnumerable<SourceFileToGenerate> files)
	{
		foreach (var file in files)
		{
			sourceGenerators.Add(file.FileName, file);
		}
	}

	public IEnumerable<SourceFileToGenerate> GetFilesToGenerate()
		=> sourceGenerators.Values;
}
