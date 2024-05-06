using Identity.API.Interfaces;
using MimeKit;

namespace Identity.API.Services;

using SmtpClient = MailKit.Net.Smtp.SmtpClient;
public class EmailSender(IConfiguration configuration) : IEmailSender
{
    public async Task SendEmailAsync(string to, string message, CancellationToken cancellationToken)
    {
        var emailConfiguration = configuration.GetSection("EmailSettings");
        
        using var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress(emailConfiguration["FromName"],
            emailConfiguration["EmailAddress"]));

        emailMessage.To.Add(new MailboxAddress("", to));
        
        emailMessage.Subject = emailConfiguration["FromName"];
        
        var bodyBuilder = new BodyBuilder { HtmlBody = message };
        
        var body = bodyBuilder.ToMessageBody();
        
        emailMessage.Body = body;  
        
        using var client = new SmtpClient();
            
        await client.ConnectAsync(emailConfiguration["SMTPServerHost"],
            int.Parse(emailConfiguration["SMTPServerPort"]!), true, cancellationToken);
        
        await client.AuthenticateAsync(emailConfiguration["EmailAddress"],
            emailConfiguration["Password"], cancellationToken);
        
        await client.SendAsync(emailMessage, cancellationToken);
        await client.DisconnectAsync(true, cancellationToken);
    }
}