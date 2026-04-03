using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace ZuraTDD;

/// <summary>
/// A collection of dependencies and fake services used in test cases.
/// </summary>
public class DependencyCollection
{
	private ImmutableDictionary<string, Lazy<FakeService>> fakeServices;

	public DependencyCollection(
		params KeyValuePair<string, Func<FakeService>>[] fakeServices)
	{
		this.fakeServices = fakeServices
			.ToImmutableDictionary(
				kvp => kvp.Key,
				kvp => new Lazy<FakeService>(kvp.Value));
	}

	/// <summary>
	/// Returns a fake service with the specified name.
	/// </summary>
	/// <param name="serviceName">Name of the service to get.</param>
	public object this[string serviceName]
		=> this.fakeServices[serviceName].Value;
}
