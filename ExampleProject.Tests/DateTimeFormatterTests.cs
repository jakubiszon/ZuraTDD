using ZuraTDD;

namespace ExampleProject.Tests;

[TestClass]
[ZuraTestClass<DateTimeFormatter>]
public partial class DateTimeFormatterTests
{
	[ZuraTest("ZuraTest - IS - passes value and abstract dependencies.")]
	private ITestPart[] FormatNowSteps => [
		Receives.GetFormattedDateTime(),

		When.Format.Is("yyyy-MM-dd HH:mm:ss"),
		When.DateTimeService.Is(new FakeDateService()),

		Expect.ResultEqualTo("2024-06-01 23:59:59")
	];

	internal class FakeDateService : IDateTimeService
	{
		public DateTime Now() => new(2024, 6, 1, 23, 59, 59);

		public DateOnly Today() => new(2024, 6, 1);
	}
}
