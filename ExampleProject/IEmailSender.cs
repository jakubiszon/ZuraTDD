namespace ExampleProject;

public interface IEmailSender
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
