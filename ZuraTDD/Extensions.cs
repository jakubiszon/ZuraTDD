using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZuraTDD;

internal static class Extensions
{
	// TODO: refactor services setup and remove this method (use constructors)
	public static void ApplyBehaviors(
		this ITestSubjectServices services,
		IEnumerable<BehaviorSetup> behaviors)
	{
		var groups = behaviors
			.Cast<BehaviorSetupServiceAssignment>()
			.GroupBy(b => b.ServiceName);

		foreach (var group in groups)
		{
			var service = services[group.Key];
			service.ApplyBehaviors(group);
		}
	}
}
