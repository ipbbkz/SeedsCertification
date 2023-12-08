using Humanizer;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace СертификацияСемян;

public class Почтальон : IEmailSender
{
    private readonly IConfiguration конфигурация;

    public Почтальон(IConfiguration конфигурация)
    {
        this.конфигурация = конфигурация ?? throw new ArgumentNullException(nameof(конфигурация));
    }

    /// <inheritdoc />
    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var client = new SmtpClient(конфигурация["Mail:Host"], int.Parse(конфигурация["Mail:Port"]));
        client.EnableSsl = true;
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        client.Credentials = new NetworkCredential(конфигурация["Mail:From"], конфигурация["Mail:Password"]);
        MailMessage mail = new MailMessage(конфигурация["Mail:From"], email, subject, htmlMessage);
        mail.IsBodyHtml = true;
        await client.SendMailAsync(mail);
    }
}
