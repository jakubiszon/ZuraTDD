namespace ZuraTDD;

public class ReturnBehavior<TValueFactory> : IReturnBehavior
{
	public ReturnBehavior(TValueFactory valueFactory)
	{
		this.ValueFactory = valueFactory;
	}

	public TValueFactory ValueFactory { get; }
}
