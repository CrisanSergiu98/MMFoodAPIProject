using MMFoodDataManagerLibrary.Internal.DataAccess;
using MMFoodDataManagerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFoodDataManagerLibrary.DataAccess
{
    public class RecipeData
    {
        public void SaveRecipe(RecipeModel recipe, string userId)
        {
            SQLDataAccess sql = new SQLDataAccess();
            RecipeIngredientData recipeIngredientData = new RecipeIngredientData();
            CategoryData categoryData = new CategoryData();
            StepData stepData = new StepData();

            RecipeDBModel dbRecipe = new RecipeDBModel();

            dbRecipe.Title = recipe.Title;
            dbRecipe.Description = recipe.Description;
            dbRecipe.PictureUrl = recipe.PictureUrl;
            dbRecipe.IPublished = false;
            dbRecipe.UserId = userId;

            dbRecipe.CategoryId = categoryData.Lookup(recipe.Category.Name);

            sql.SaveData("dbo.spRecipeIngredient_Insert", dbRecipe, "MMFoodData");

            dbRecipe.Id = Lookup(dbRecipe.Title, dbRecipe.UserId); 

            //Save Ingredients
            foreach (var i in recipe.RecipeIngredients)
            {
                recipeIngredientData.SaveRecipeIngredient(i, dbRecipe.Id);
            }    
            
            //Save Steps
            foreach(var s in recipe.Steps)
            {
                s.RecipeId = dbRecipe.Id;
                stepData.Save(s);
            }
        }

        public int Lookup(string title, string userId)
        {
            SQLDataAccess sql = new SQLDataAccess();
            return sql.LoadData<int, dynamic>("dbo.spRecipe_Lookup", new { Title = title, UserId = userId }, "MMFoodData").FirstOrDefault();
        }
    }
}
