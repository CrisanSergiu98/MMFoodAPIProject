
using MMFoodDesktopUILibary.Models;
using MMFoodDesktopUILibrary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MMFoodDesktopUILibrary.Api
{ 
    public class APIHelper : IAPIHelper
    {
        public HttpClient apiClient;
        private ILoggedInUserModel _loggedInUser;

        public APIHelper( ILoggedInUserModel loggedInUser)
        {
            _loggedInUser = loggedInUser;
            InitializeClient();
        }

        /// <summary>
        /// Initializing the HTTPClient
        /// </summary>
        private void InitializeClient()
        {
            // Get the api's value from app.config
            string api = ConfigurationManager.AppSettings["api"];

            apiClient = new HttpClient();
            // Assign the api string to the BaseAddress of the client
            apiClient.BaseAddress = new Uri(api);
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// The Authenticate fuction
        /// 
        /// Makes an API Call to get the authToken
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<AuthenticatedUser> Authenticate(string username, string password)
        {
            // Creating our pairs for the PostAsync
            var data = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                ["grant_type"] = "password",
                ["username"] = username,
                ["password"] = password
            });
            // Creating an PostAsync for out /token route and passing in the value pairs we set up above.
            using (HttpResponseMessage response = await apiClient.PostAsync("/Token", data))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<AuthenticatedUser>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task GetLogedinUserInfo(string token)
        {
            apiClient.DefaultRequestHeaders.Clear();
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            apiClient.DefaultRequestHeaders.Add("Authorization", $"bearer {token}");

            using (HttpResponseMessage response = await apiClient.GetAsync("api/User"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<LoggedInUserModel>();
                    _loggedInUser.CreateDate = result.CreateDate;
                    _loggedInUser.Email = result.Email;
                    _loggedInUser.Username = result.Username;
                    _loggedInUser.Id = result.Id;
                    _loggedInUser.Token = token;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
