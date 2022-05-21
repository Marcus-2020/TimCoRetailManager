using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TRMDesktopUI.Library.Models;

namespace TRMDesktopUI.Library.Api
{
    public class ApiHelper : IApiHelper
    {
        private readonly ILoggedInUserModel _loggedInUser;
        private HttpClient _apiClient { get; set; }

        public ApiHelper(ILoggedInUserModel loggedInUser)
        {
            _loggedInUser = loggedInUser;
            InitializeClient();
        }

        private void InitializeClient()
        {
            string api = ConfigurationManager.AppSettings["api"];
            
            _apiClient = new HttpClient();
            _apiClient.BaseAddress = new Uri(api);
            _apiClient.DefaultRequestHeaders.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<AuthenticatedUser> Authtenticate(string username, string password)
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
            });

            using (HttpResponseMessage response = await _apiClient.PostAsync("token", data))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<AuthenticatedUser>();
                    return result;
                }
                
                throw new Exception(response.ReasonPhrase);
            }
        }
        
        public async Task GetLoggedInUserData(string token)
        {
            _apiClient.DefaultRequestHeaders.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _apiClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            
            using (HttpResponseMessage response = await _apiClient.GetAsync("api/user"))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }
                
                var result = await response.Content.ReadAsAsync<LoggedInUserModel>();
                result.Token = token;

                UpdateLoggedInUser(token, result);
            }
        }

        private void UpdateLoggedInUser(string token, LoggedInUserModel result)
        {
            _loggedInUser.Token = token;
            _loggedInUser.Id = result.Id;
            _loggedInUser.FirstName = result.FirstName;
            _loggedInUser.LastName = result.LastName;
            _loggedInUser.EmailAddress = result.EmailAddress;
            _loggedInUser.CreatedDate = result.CreatedDate;
        }
    }
}