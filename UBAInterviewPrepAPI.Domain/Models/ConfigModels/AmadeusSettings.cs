using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UBAInterviewPrepAPI.Domain.Models.ConfigModels
{
    public class AmadeusSettings
    {
        public string BaseUrl { get; set; }
        public string GrantType { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }

    }
}
