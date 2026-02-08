namespace ExampleProject;

internal interface IEmailSender
{
	Task SendEmail(
		string to,
		string subject,
		string body);

	void SendEmailSync(
		string to,
		string subject,
		string body);
}
