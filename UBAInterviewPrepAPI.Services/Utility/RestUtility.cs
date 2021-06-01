using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using UBAInterviewPrepAPI.Domain.Models.ConfigModels;

namespace UBAInterviewPrepAPI.Services.Utility
{
    public class RestUtility
    {
        private static AmadeusSettings _amadeusSettings;
        private static ILogger _logger;
        public RestUtility(IOptions<AmadeusSettings> amadeusSettings, ILogger<RestUtility> logger)
        {
            _amadeusSettings = amadeusSettings.Value;
            _logger = logger;
        }       

        public static T Get<T>(string RelativeUrl) where T : new()
        {
            T result = new T();
            //var result = new TResponse();
            string AccessToken = GetBearerToken();
            string ApiUrl = $"{_amadeusSettings.BaseUrl}{RelativeUrl}";

            try
            {
                //bypass all server certificate wahala...
                ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                RestClient restClient = new RestClient($"{ApiUrl}");
                RestRequest restRequest = new RestRequest(Method.GET);
                //restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                restRequest.AddHeader("Content-Type", "application/json");
                restRequest.AddHeader("Authorization", $"Bearer {AccessToken}");

                IRestResponse<T> response = restClient.Execute<T>(restRequest);

                result = response.Data;
                _logger.LogInformation($"REQUEST MADE TO ENDPOINT => {ApiUrl} STATUS => SUCCESS");

            }
            catch (Exception ex)
            {
                //return result;
                _logger.LogError($"ERROR OCCURRED REQUEST MADE TO ENDPOINT => {ApiUrl} STATUS => FAILED EXCEPTION => {ex.Message}");

            }

            return result;
        }

        public static string GetBearerToken()
        {
            RestClient client = new RestClient("https://test.api.amadeus.com/v1/security/oauth2/token");
            client.Timeout = -1;
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", $"grant_type={_amadeusSettings.GrantType}&client_id={_amadeusSettings.ClientId}&client_secret={_amadeusSettings.ClientSecret}", ParameterType.RequestBody);
            IRestResponse<TokenResponse> response = client.Execute<TokenResponse>(request);

            var result = response.Data;

            return result.AccessToken;
        }

        public static T GetWithParameters<T>(string RelativeUrl, Dictionary<string, object> requestParams = null) where T : new()
        {
            T result = new T();
            string AccessToken = GetBearerToken();
            string ApiUrl = $"{_amadeusSettings.BaseUrl}{RelativeUrl}";

            try
            {
                ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                RestClient restClient = new RestClient($"{ApiUrl}");
                RestRequest restRequest = new RestRequest(Method.POST);
                restRequest.AddHeader("Content-Type", "application/json");
                restRequest.AddHeader("Authorization", $"Bearer {AccessToken}");

                if (requestParams != null)
                {
                    foreach (var item in requestParams)
                    {
                        restRequest.AddParameter(item.Key, item.Value, ParameterType.QueryStringWithoutEncode);
                    }
                }

                IRestResponse<T> response = restClient.Execute<T>(restRequest);

                result = response.Data;
                _logger.LogInformation($"REQUEST MADE TO ENDPOINT => {ApiUrl} STATUS => SUCCESS");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"EXCEPTION {ex.Message}\n {ex.StackTrace}");
                _logger.LogError($"ERROR OCCURRED REQUEST MADE TO ENDPOINT => {ApiUrl} STATUS => FAILED EXCEPTION => {ex.Message}");
                //return result;
            }

            return result;
        }

        public static T Post<T>(string RelativeUrl, object requestObject) where T : new()
        {
            T result = new T();
            string AccessToken = GetBearerToken();
            string ApiUrl = $"{_amadeusSettings.BaseUrl}{RelativeUrl}";

            try
            {
                ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                RestClient restClient = new RestClient($"{ApiUrl}");
                RestRequest restRequest = new RestRequest(Method.POST);
                restRequest.AddHeader("Content-Type", "application/json");
                restRequest.AddHeader("Authorization", $"Bearer {AccessToken}");

                restRequest.AddJsonBody(requestObject);

                IRestResponse<T> response = restClient.Execute<T>(restRequest);

                result = response.Data;
                _logger.LogInformation($"REQUEST MADE TO ENDPOINT => {ApiUrl} STATUS => SUCCESS");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"EXCEPTION {ex.Message}\n {ex.StackTrace}");
                _logger.LogError($"ERROR OCCURRED REQUEST MADE TO ENDPOINT => {ApiUrl} STATUS => FAILED EXCEPTION => {ex.Message}");

            }

            return result;
        }

        public static T Put<T>(string RelativeUrl, object requestObject) where T : new()
        {
            T result = new T();
            string AccessToken = GetBearerToken();
            string ApiUrl = $"{_amadeusSettings.BaseUrl}{RelativeUrl}";

            try
            {
                ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                RestClient restClient = new RestClient($"{ApiUrl}");
                RestRequest restRequest = new RestRequest(Method.PUT);
                //restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                restRequest.AddHeader("Content-Type", "application/json");
                restRequest.AddHeader("Authorization", $"Bearer {AccessToken}");

                restRequest.AddJsonBody(requestObject);

                IRestResponse<T> response = restClient.Execute<T>(restRequest);

                result = response.Data;
                _logger.LogInformation($"REQUEST MADE TO ENDPOINT => {ApiUrl} STATUS => SUCCESS");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"EXCEPTION {ex.Message}\n {ex.StackTrace}");
                _logger.LogError($"ERROR OCCURRED REQUEST MADE TO ENDPOINT => {ApiUrl} STATUS => FAILED EXCEPTION => {ex.Message}");

            }

            return result;
        }
    }
}
