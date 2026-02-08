using System.Collections;
using System.Reflection;
using ZuraTDD;

namespace ExampleProject.Tests;

/// <summary>
/// Marks a method as a source of test cases.
/// The method will receive an auto-generated test runner method.
/// </summary>
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = false)]
public class TestCasesAttribute : Attribute, ITestDataSource
{
	public TestCasesAttribute()
	{
	}

	public IEnumerable<object[]> GetData(MethodInfo methodInfo)
	{
		var result = methodInfo.Invoke(null, null);
		if (result is IEnumerable enumerable)
		{
			foreach (var testCase in enumerable)
			{
				yield return [testCase];
			}
		}
	}

	public string? GetDisplayName(MethodInfo methodInfo, object?[]? data)
	{
		if (data?.Length > 0 && data[0] is TestCase testCase)
		{
			return testCase.Name;
		}
		else
		{
			throw new Exception("The method marked as [TestCases] must return an IEnumerable of objects inheriting TestCase.");
		}
	}
}