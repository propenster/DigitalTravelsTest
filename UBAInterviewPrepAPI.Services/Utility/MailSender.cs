using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using UBAInterviewPrepAPI.Domain.Models.ConfigModels;
using UBAInterviewPrepAPI.Domain.Models.Email;

namespace UBAInterviewPrepAPI.Services.Utility
{
    public class MailSender : IMailSender
    {
        MailSettings _mailSettings;

        public MailSender(MailSettings mailSettings)
        {
            _mailSettings = mailSettings;
        }
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.FromEmail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            if(mailRequest.Attachements != null)
            {
                byte[] fileBytes;
                foreach (var file in mailRequest.Attachements)
                {
                    if(file.Length > 0)
                    {
                        using(var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }

            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.FromEmail, _mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
