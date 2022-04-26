﻿using MMFoodDesktopUILibary.Models;
using MMFoodDesktopUILibrary.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MMFoodDesktopUILibary.Api
{
    public class CategoryEndPoint : ICategoryEndPoint
    {
        IAPIHelper _apiHelper;
        public CategoryEndPoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<CategoryModel>> GetAll()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("api/Category"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<CategoryModel>>();
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