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
    public class RecipeEndPoint : IRecipeEndPoint
    {
        IAPIHelper _apiHelper;
        public RecipeEndPoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task PostRecipe(RecipeModel recipe)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync("/api/Recipe", recipe))
            {
                if (response.IsSuccessStatusCode)
                {
                    // TODO:
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

    }
}
