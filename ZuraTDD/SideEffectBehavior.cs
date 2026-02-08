using System;

namespace ZuraTDD;

/// <summary>
/// Defines a side effect behavior calling a delegate when invoked.
/// </summary>
/// <typeparam name="TAction">Type of <see cref="System.Action" /> to call with this instance.</typeparam>
public record SideEffectBehavior<TAction> : IInvokeBehavior
	where TAction : Delegate
{
	public SideEffectBehavior(TAction sideEffectAction)
	{
		this.SideEffectAction = sideEffectAction;
	}

	public TAction SideEffectAction { get; }
}
