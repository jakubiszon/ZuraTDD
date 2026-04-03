using System;

namespace ZuraTDD.Generator;

/// <summary>
/// Represents a source file to be generated.
/// </summary>
internal record SourceFileToGenerate
{
	public string FileName { get; }

	public Func<string> GeneratorFunction { get; }

	public SourceFileToGenerate(
		string fileName,
		Func<string> generatorFunction)
	{
		FileName = fileName;
		GeneratorFunction = generatorFunction;
	}
}
