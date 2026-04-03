using ZuraTDD;
using static ExampleProject.Tests.DateTimeFormatterTestCase;

namespace ExampleProject.Tests;

[TestClass]
public partial class DateTimeFormatterTests
{
	[ZuraTest<DateTimeFormatterTestCase>("ZuraTest - IS - passes value and abstract dependencies.")]
	private ITestPart[] FormatNowSteps => [
		Receives.GetFormattedDateTime(),

		When.Format.Is("yyyy-MM-dd HH:mm:ss"),
		When.DateTimeService.Is(new FakeDateService()),

		Expect.ResultEqualTo("2024-06-01 23:59:59")
	];

	internal class FakeDateService : IDateTimeService
	{
		public DateTime Now() => new DateTime(2024, 6, 1, 23, 59, 59);

		public DateOnly Today() => new DateOnly(2024, 6, 1);
	}
}
