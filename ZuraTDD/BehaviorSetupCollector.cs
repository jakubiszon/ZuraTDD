using System.Collections.Generic;
using System.Linq;

namespace ZuraTDD;

/// <summary>
/// Stateful setup collector recording behavior builders for conversion to
/// behavior setups when an instance of the fake object is created.
/// </summary>
public class BehaviorSetupCollector : IBehaviorSetupProcessor
{
	/// <summary>
	/// Builders recorded for conversion to <see cref="BehaviorSetup"/> when an instance of
	/// the fake object is created.
	/// </summary>
	private List<BehaviorBuilder> builders = new();

	/// <summary>
	/// Adds the specified behavior setup to the processor.
	/// </summary>
	/// <param name="behaviorBuilder">Behavior setup to add.</param>
	public BehaviorSetup Build(
		BehaviorBuilder behaviorBuilder)
	{
		return new(
			behaviorBuilder.Method,
			behaviorBuilder.ValueSetConstraint,
			behaviorBuilder.Behaviors);
	}

	public void BuildInitiated(BehaviorBuilder behaviorSetup)
	{
		this.builders.Add(behaviorSetup);
	}

	/// <summary>
	/// Converts all recorded builders to behavior setups.
	/// </summary>
	public IReadOnlyList<BehaviorSetup> BuildSetupCollection()
	{
		return builders
			.Select(builder => builder.ToBehaviorSetup())
			.ToList();
	}
}
