using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Application.Services;

public class EmailService : IEmailService
{
    private readonly EmailConfiguration _emailConfig;

    public EmailService(IOptions<EmailConfiguration> emailConfig)
    {
        _emailConfig = emailConfig.Value;
    }
    
    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var client = new SendGridClient(_emailConfig.ApiKey);
        var from = new EmailAddress(_emailConfig.Email, _emailConfig.Company);
        var to = new EmailAddress(email);
        var plainTextContent = htmlMessage;
        var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlMessage);

        var response = await client.SendEmailAsync(msg);

        if (response.StatusCode != System.Net.HttpStatusCode.OK &&
            response.StatusCode != System.Net.HttpStatusCode.Accepted)
        {
            throw new Exception($"Failed to send email: {response.StatusCode}");
        }
    }
}

public class EmailConfiguration
{
    public string ApiKey { get; set; }
    public string Email { get; set; }
    public string Company { get; set; }
}