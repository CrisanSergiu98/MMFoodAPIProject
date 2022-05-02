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
    public class RecipeController : ApiController
    {
        public void Post(RecipeModel recipe)
        {
            RecipeData data = new RecipeData();
            string userId = RequestContext.Principal.Identity.GetUserId();

            data.SaveRecipe(recipe, userId);
        }
    }
}
