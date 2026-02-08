namespace ZuraTDD;

/// <summary>
/// An object used to match sets of values to specific value constraints.
/// </summary>
public class ValueSetConstraint
{
	public IValueConstraint[] Constraints { get; }

	public ValueSetConstraint(params IValueConstraint[] valueConstraints)
	{
		this.Constraints = valueConstraints;
	}

	public bool Matches(object?[] actualParameters)
	{
		if (actualParameters.Length != this.Constraints.Length)
		{
			return false;
		}

		for (int i = 0; i < this.Constraints.Length; i++)
		{
			if (!this.Constraints[i].IsMatching(actualParameters[i]))
			{
				return false;
			}
		}

		return true;
	}
}
