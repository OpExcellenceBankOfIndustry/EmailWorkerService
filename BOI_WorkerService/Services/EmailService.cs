using BOI_WorkerService.Entities;
using BOI_WorkerService.Helpers;
using BOI_WorkerService.Models.ConfigurationModels;
using BOI_WorkerService.Persistence.Mail;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI_WorkerService.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfigurationSettings _mailSettings;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IOptions<EmailConfigurationSettings> options, ILogger<EmailService> logger)
        {
            _mailSettings = options.Value;
            _logger = logger;
        }

        public async Task<bool> SendEmailAsync(EmailRequest email)
        {
            var message = await email.RecieverEmailAddresses();
            message.From.Add(new MailboxAddress(_mailSettings.BankName, _mailSettings.EmailFrom));
            message.To.Add(MailboxAddress.Parse(email.ToRecipient));
            message.Subject = email.Subject;

            message.Body = email.IsHtml
                ? new TextPart("html") { Text = email.Message }
                : new TextPart("plain") { Text = email.Message };

            var builder = new BodyBuilder();

            if (email.IsHtml)
            {
                builder.HtmlBody = email.Message;
            }
            else
            {
                builder.TextBody = email.Message;
            }

            if (email.HasAttachment)
            {
                foreach (var emailattachement in email.EmailAttachmentsRequest)
                {
                    builder.Attachments.Add(emailattachement.FileName, emailattachement.Attachment);
                }
            }

            message.Body = builder.ToMessageBody();
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            _logger.LogInformation("About to call smtp server", "");

            var client = new SmtpClient();
            //client.CheckCertificateRevocation = false;
            client.Connect(_mailSettings.SmtpHost, _mailSettings.SmtpPort, SecureSocketOptions.None); 
            //client.Connect("192.168.0.72", 25, SecureSocketOptions.None); 

            // Note: only needed if the SMTP server requires authentication
            client.Authenticate(_mailSettings.SmtpUser, _mailSettings.SmtpPassword);

            await client.SendAsync(message);
            client.Disconnect(true);
            _logger.LogInformation("after calling smtp server", "");

            return true;
        }
    }
}
