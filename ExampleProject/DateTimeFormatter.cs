namespace ExampleProject;

public class DateTimeFormatter
{
	private readonly string format;
	private readonly IDateTimeService dateTimeService;

	public DateTimeFormatter(
		string format,
		IDateTimeService dateTimeService)
	{
		this.format = format;
		this.dateTimeService = dateTimeService;
	}

	public string GetFormattedDateTime()
	{
		return this.dateTimeService
			.Now()
			.ToString(this.format);
	}
}
