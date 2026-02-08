using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ZuraTDD.MsTest;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public sealed class TestCaseRunnerAttribute : Attribute, ITestDataSource
{
	private readonly string _producerMethodName;

	public TestCaseRunnerAttribute(string producerMethodName)
	{
		_producerMethodName = producerMethodName;
	}

	public IEnumerable<object[]> GetData(MethodInfo testMethod)
	{
		var declaringType = testMethod.DeclaringType
			?? throw new InvalidOperationException("Test method has no declaring type.");

		var producer = declaringType.GetMethod(
			_producerMethodName,
			BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

		if (producer is null)
			throw new InvalidOperationException(
				$"Could not find data producer method '{_producerMethodName}'.");

		if (producer.GetCustomAttribute<TestCasesAttribute>() is null)
			throw new InvalidOperationException(
				$"Method '{_producerMethodName}' is not marked with [TestCases].");

		if (producer.Invoke(null, null) is not IEnumerable<TestCase> cases)
			throw new InvalidOperationException(
				$"Method '{_producerMethodName}' must return IEnumerable<TestCase>.");

		foreach (var testCase in cases)
		{
			// Single-parameter test method
			yield return new object[] { testCase };
		}
	}

	#pragma warning disable CS8614 // Nullability of reference types in type of parameter doesn't match implicitly implemented member.
	public string GetDisplayName(MethodInfo methodInfo, object[] data)
	#pragma warning restore CS8614 // Nullability of reference types in type of parameter doesn't match implicitly implemented member.
	{
		if (data[0] is TestCase tc)
			return $"{methodInfo.Name}({tc.Name})";

		return methodInfo.Name;
	}
}