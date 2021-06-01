﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UBAInterviewPrepAPI.Domain.Models.ConfigModels
{
    public struct TokenResponse
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("application_name")]
        public string ApplicationName { get; set; }
        [JsonProperty("client_id")]
        public string ClientId { get; set; }
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("scope")]
        public string Scope { get; set; }

    }
}
