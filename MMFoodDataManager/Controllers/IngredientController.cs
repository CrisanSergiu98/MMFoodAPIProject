using MMFoodDataManagerLibrary.DataAccess;
using MMFoodDataManagerLibrary.Models;
using MMFoodDataManagerLibrary.Internal.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MMFoodDataManager.Controllers
{
    [Authorize]
    public class IngredientController : ApiController
    {
        public List<IngredientDBModel> Get(string name)
        {
            IngredientData data = new IngredientData();

            return data.SearchByName(name);            
        }
    }
}
