using MMFoodDesktopUILibary.Models;
using MMFoodDesktopUILibrary.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MMFoodDesktopUILibary.Api
{
    public class AccountEndPoint : IAccountEndPoint
    {
        IAPIHelper _apiHelper;

        public AccountEndPoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task CreateAccount(RegisterBindingModel newUser)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync("api/Account/Register", newUser))
            {
                if (response.IsSuccessStatusCode)
                {
                    //TODO
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

    }
}
