namespace ZuraTDD;

/// <summary>
/// Marks a class as a mock for the service <typeparamref name="TService" />.
/// The mocking code will be automatically generated.
/// <code>
/// // use it with partial class and pass the interface to mock
/// public partial class MyClassMock : IMock&lt;IMyClass&gt; {
///	  // nothing more needed
/// }
/// 
/// // inside your tests:
/// var (builder, instance, expect) = new MyClassMock();
/// 
/// // setting up behaviors
/// builder.ExampleMethod()
///   .Returns(someValue);
/// 
/// // after you run your tests you can
/// expect.ExampleMethod(
///   exampleParam: 123)
///	  .WasCalled();
/// </code>
/// </summary>
/// <typeparam name="TService">Type to create mocking code for.</typeparam>
public interface IMock<TService>
{
}
