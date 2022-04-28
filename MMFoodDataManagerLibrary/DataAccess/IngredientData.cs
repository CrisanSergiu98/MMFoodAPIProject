using MMFoodDataManagerLibrary.Internal.DataAccess;
using MMFoodDataManagerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFoodDataManagerLibrary.DataAccess
{
    public class IngredientData
    {
        public IngredientDBModel SaveIngredient(IngredientModel ingredient)
        {
            IngredientDBModel ingredientDB = new IngredientDBModel();

            try
            {
                ingredientDB = GetIngredientByName(ingredient.Name);
            }
            catch
            {

            }

            return ingredientDB;
        }

        public List<IngredientDBModel> GetAllIngredients()
        {
            SQLDataAccess sql = new SQLDataAccess();

            var output = sql.LoadData<IngredientDBModel, dynamic>("dbo.spIngredient_GetAll", new { }, "MMFoodData");

            return output;
        }

        public IngredientDBModel GetIngredientByName(string name)
        {
            SQLDataAccess sql = new SQLDataAccess();

            var output = sql.LoadData<IngredientDBModel, dynamic>("dbo.spIngredient_GetByName", new { }, "MMFoodData").FirstOrDefault();

            return output;
        }
    }
}
