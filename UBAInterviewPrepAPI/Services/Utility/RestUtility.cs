using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace UBAInterviewPrepAPI.Services.Utility
{
    public static class RestUtility
    {

        const string BASE_URL = "https://test.api.amadeus.com/v2";
        static internal T Get<T>(string relativeUrl) where T : new()
        {

            T result = new T();
            string AccessToken = GetBearerToken();

            try
            {
                ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                RestClient restClient = new RestClient($"{BASE_URL}{relativeUrl}");
                RestRequest restRequest = new RestRequest(Method.GET);
                //restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                restRequest.AddHeader("Content-Type", "application/json");
                restRequest.AddHeader("Authorization", $"Bearer {AccessToken}");

                IRestResponse<T> response = restClient.Execute<T>(restRequest);

                result = response.Data;

            }
            catch (Exception ex)
            {

                return result;
            }

            return result;
        }



        static string GetBearerToken()
        {
            RestClient client = new RestClient("https://test.api.amadeus.com/v1/security/oauth2/token");
            client.Timeout = -1;
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            string client_id = "LYu9M4285UD22aH63GGGtiUGI2MypcA9";
            string client_secret = "iHhLnRwgyuql52dm";
            request.AddBody($"grant_type=client_credentials&client_id={client_id}&client_secret={client_secret}");
            IRestResponse<TokenResponse> response = client.Execute<TokenResponse>(request);

            var result = response.Data;

            return result.AccessToken;

        }


        static internal T GetWithParameters<T>(string relativeUrl, Dictionary<string, object> requestParams = null) where T : new()
        {

            T result = new T();
            string AccessToken = GetBearerToken();

            try
            {
                ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                RestClient restClient = new RestClient($"{BASE_URL}{relativeUrl}");
                RestRequest restRequest = new RestRequest(Method.POST);
                //restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                restRequest.AddHeader("Content-Type", "application/json");
                restRequest.AddHeader("Authorization", $"Bearer {AccessToken}");

                if(requestParams != null)
                {
                    foreach (var item in requestParams)
                    {
                        restRequest.AddParameter(item.Key, item.Value, ParameterType.QueryStringWithoutEncode);
                    }
                }

                IRestResponse<T> response = restClient.Execute<T>(restRequest);

                result = response.Data;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"EXCEPTION {ex.Message}\n {ex.StackTrace}");
                return result;
            }

            return result;
        }



        static internal T Post<T>(string relativeUrl, object requestObject) where T : new()
        {

            T result = new T();
            string AccessToken = GetBearerToken();

            try
            {
                ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                RestClient restClient = new RestClient($"{BASE_URL}{relativeUrl}");
                RestRequest restRequest = new RestRequest(Method.POST);
                //restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                restRequest.AddHeader("Content-Type", "application/json");
                restRequest.AddHeader("Authorization", $"Bearer {AccessToken}");

                restRequest.AddJsonBody(requestObject);

                IRestResponse<T> response = restClient.Execute<T>(restRequest);

                result = response.Data;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"EXCEPTION {ex.Message}\n {ex.StackTrace}");
                return result;
            }

            return result;
        }


    }

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