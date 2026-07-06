using System.Collections;

namespace ExampleProject.Insanity;

public interface IDefineGenericWhereMethods
{
	void DoSomething<T>() where T : class;

	void DoSomething<T1, T2>()
		where T1 : struct
		where T2 : class;

	void DoSomething<T1, T2, T3>()
		where T1 : class, IEnumerable
		where T2 : notnull
		where T3 : class, new();
}
