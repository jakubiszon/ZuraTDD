using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace ZuraTDD;

/// <summary>
/// A collection of mocked-objects used in test cases.
/// </summary>
public class DependencyCollection
{
	private ImmutableDictionary<string, Lazy<MockedObject>> mockedObjects;

	public DependencyCollection(
		params KeyValuePair<string, Func<MockedObject>>[] mockedObjects)
	{
		this.mockedObjects = mockedObjects
			.ToImmutableDictionary(
				kvp => kvp.Key,
				kvp => new Lazy<MockedObject>(kvp.Value));
	}

	/// <summary>
	/// Returns a mocked-object with the specified name.
	/// </summary>
	/// <param name="dependencyName">Name of the mocked-object to get.</param>
	public MockedObject this[string dependencyName]
		=> this.mockedObjects[dependencyName].Value;
}
