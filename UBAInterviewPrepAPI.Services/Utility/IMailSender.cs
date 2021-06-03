using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UBAInterviewPrepAPI.Domain.Models.Email;

namespace UBAInterviewPrepAPI.Services.Utility
{
    public interface IMailSender
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
