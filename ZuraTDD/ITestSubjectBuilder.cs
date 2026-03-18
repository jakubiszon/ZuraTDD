namespace ZuraTDD;

/// <summary>
/// Work in progress.
/// </summary>
///// <summary>
///// Marks an object as a "test subject builder" which will receive generated implementation.
///// The builder will expose mock-builder properties representing dependencies of TTestSubject.
///// </summary>
///// <typeparam name="TTestSubject">The class which you want to test.</typeparam>
public interface ITestSubjectBuilder<TTestSubject>
	: IBuild<TTestSubject>
{
}
