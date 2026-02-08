using System.Collections.Generic;
using System.Collections.Immutable;

namespace ZuraTDD;

/// <summary>
/// A collection of fake services used in test cases.
/// </summary>
public class FakeServices : ITestSubjectServices
{
	private ImmutableDictionary<string, FakeService> fakeServices;

	public FakeServices(
		params KeyValuePair<string, FakeService>[] fakeServices)
	{
		this.fakeServices = fakeServices
			.ToImmutableDictionary(
				kvp => kvp.Key,
				kvp => kvp.Value);
	}

	/// <summary>
	/// Returns a fake service with the specified name.
	/// </summary>
	/// <param name="serviceName">Name of the service to get.</param>
	public FakeService this[string serviceName] => this.fakeServices[serviceName];
}
