using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace UBAInterviewPrepAPI.Domain.Models.Email
{
    public class MailRequest
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body  { get; set; }
        public List<IFormFile> Attachements { get; set; }

        
    }
}
