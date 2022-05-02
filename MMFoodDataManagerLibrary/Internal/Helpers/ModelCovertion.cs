using MMFoodDataManagerLibrary.DataAccess;
using MMFoodDataManagerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFoodDataManagerLibrary.Internal.Helpers
{
    public static class ModelCovertion
    {
        public static IngredientModel IngredientFromDBModelToModel(IngredientDBModel input)
        {
            IngredientModel output = new IngredientModel();
            IngredientCategoryData categoryData = new IngredientCategoryData();

            output.Name = input.Name;
            output.Description = input.Description;
            output.PictureUrl = input.PictureUrl;
            output.Category = categoryData.GetById(input.CategoryId);

            return output;
        }
    }
}
