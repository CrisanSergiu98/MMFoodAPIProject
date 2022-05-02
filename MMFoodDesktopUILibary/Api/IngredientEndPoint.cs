using MMFoodDesktopUILibrary.Api;
using MMFoodDesktopUILibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MMFoodDesktopUILibary.Api
{
    public class IngredientEndPoint : IIngredientEndPoint
    {
        IAPIHelper _apiHelper;

        public IngredientEndPoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<IngredientModel>> GetFirstTenIngredients(string name)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"api/Recipe/{name}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<IngredientModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
