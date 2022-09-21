using BOI_WorkerService.Entities;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI_WorkerService.Helpers
{
    public static class EmailHelper
    {
        public static Task<MimeMessage> RecieverEmailAddresses(this EmailRequest email)
        {
            var message = new MimeMessage();
            foreach (var to in email.ToRecipient.Split(new char[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                message.To.Add(MailboxAddress.Parse(to.Trim()));
            }

            if (!string.IsNullOrEmpty(email.CcRecipient))
            {
                foreach (var cc in email.CcRecipient.Split(new char[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    message.Cc.Add(MailboxAddress.Parse(cc.Trim()));
                }
            }
            if (!string.IsNullOrEmpty(email.BccRecipient))
            {
                foreach (var bcc in email.BccRecipient.Split(new char[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    message.Bcc.Add(MailboxAddress.Parse(bcc.Trim()));
                }
            }

            return Task.FromResult(message);
        }
    }
}
