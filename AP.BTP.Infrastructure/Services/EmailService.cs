using AP.BTP.Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace AP.BTP.Infrastructure.Services;

public class EmailService : IEmailService
{
    private readonly ILogger<EmailService> logger;

    public EmailService(ILogger<EmailService> logger)
    {
        this.logger = logger;
    }
    public Task SendEmailAsync(string to, string subject, string body)
    {
        logger.LogInformation("Sending fake email to {To}.\nSubject: {Subject}.\nBody: {Body}", to, subject, body);
        return Task.CompletedTask;
    }
}