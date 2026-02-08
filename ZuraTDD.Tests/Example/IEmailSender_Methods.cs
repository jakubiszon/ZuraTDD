using ExampleProject;
using System.Reflection;

namespace ZuraTDD.Tests.Example;

// generated when user needs fake IEmailSender or TestCase which consumes IEmailSender
internal static class IEmailSender_Methods
{
	public static readonly MethodInfo SendEmail = typeof(IEmailSender).GetMethod(
		nameof(IEmailSender.SendEmail),
		[typeof(string), typeof(string), typeof(string)])!;

	public static readonly MethodInfo SendEmailSync = typeof(IEmailSender).GetMethod(
		nameof(IEmailSender.SendEmailSync),
		[typeof(string), typeof(string), typeof(string)])!;
}
