using MMFoodDataManagerLibrary.Internal.DataAccess;
using MMFoodDataManagerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFoodDataManagerLibrary.DataAccess
{
    public class RecipeIngredientData
    {
        public void SaveRecipeIngredient(RecipeIngredientModel ingredient, int recipeId)
        {
            SQLDataAccess sql = new SQLDataAccess();
            IngredientData ingredientData = new IngredientData();

            RecipeIngredientDBModel toSaveRecipeIngredient = new RecipeIngredientDBModel();


            toSaveRecipeIngredient.IngredientId = ingredientData.Lookup(ingredient.Ingredient.Name);
            toSaveRecipeIngredient.RecipeId = recipeId;
            toSaveRecipeIngredient.Quantity = ingredient.Quantity;
            toSaveRecipeIngredient.Unit = ingredient.Unit;
            toSaveRecipeIngredient.IsRequired = ingredient.IsReqired;

            try
            {
                sql.SaveData("dbo.spRecipeIngredient_Insert", toSaveRecipeIngredient, "MMFoodData");                
            }
            catch(Exception e)
            {
                string i = e.Message;
            }
        }
    }
}
