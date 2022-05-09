using Microsoft.AspNet.Identity;
using MMFoodDataManagerLibrary.DataAccess;
using MMFoodDataManagerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MMFoodDataManager.Controllers
{
    [Authorize]
    public class CategoryController : ApiController
    {
        //public List<CategoryDBModel> Get()
        //{
        //    //string userId = RequestContext.Principal.Identity.GetUserId();

        //    CategoryData data = new CategoryData();

        //    return data.GetAllCategories();
        //}

        public List<CategoryDBModel> Get(string name)
        {
            //string userId = RequestContext.Principal.Identity.GetUserId();

            CategoryData data = new CategoryData();

            return data.SearchByName(name);
        }
    }
}
