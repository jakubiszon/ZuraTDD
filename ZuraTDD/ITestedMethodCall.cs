using System.Threading.Tasks;

namespace ZuraTDD;

/// <summary>
/// Represents the call to a method within the TestCase.
/// </summary>
public interface ITestedMethodCall : ITestPart
{
	Task<object?> CallAsync(object target);
}
