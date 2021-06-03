using System;
using System.Collections.Generic;
using System.Text;

namespace UBAInterviewPrepAPI.Domain.Models.ConfigModels
{
    public class MailSettings
    {
        public string FromEmail { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
}
