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
            RecipeIngredientData recipeIngredientData = new RecipeIngredientData();
            CategoryData categoryData = new CategoryData();
            StepData stepData = new StepData();

            List<RecipeIngredientDBModel> recipeIngredients = new List<RecipeIngredientDBModel>();

            RecipeDBModel dbRecipe = new RecipeDBModel
            {
                Name = recipe.Name,
                Description = recipe.Description,
                PictureUrl = recipe.PictureUrl,
                IPublished = false,
                UserId = userId,
                CategoryId = recipe.Category.Id
            };

            foreach(var i in recipe.RecipeIngredients)
            {
                recipeIngredients.Add(new RecipeIngredientDBModel
                {
                    IngredientId=i.Ingredient.Id,
                    Quantity = i.Quantity,
                    Unit=i.Unit
                    
                });
            }            

            using (SQLDataAccess sql = new SQLDataAccess())
            {
                try
                {
                    sql.StartTranzaction("MMFoodData");

                    //Save the Recipe
                    sql.SaveDataInTranzaction("dbo.spRecipe_Insert", dbRecipe);

                    //Get the Recipe Id
                    dbRecipe.Id = sql.LoadDataInTranzaction<int, dynamic>("dbo.spRecipe_Lookup", new { dbRecipe.Name, dbRecipe.UserId }).FirstOrDefault();

                    //Save the Ingredient List
                    foreach (var i in recipeIngredients)
                    {
                        i.RecipeId = dbRecipe.Id;

                        sql.SaveDataInTranzaction("dbo.spRecipeIntredient_Insert", i);
                    }

                    //Save Setps
                    foreach (var i in recipe.Steps)
                    {
                        i.RecipeId = dbRecipe.Id;

                        sql.SaveDataInTranzaction("dbo.spStep_Insert", i);
                    }
                }
                catch (Exception ex)
                {

                    sql.RollbackTranzaction();
                    throw;
                }
            }            
        }

        public int Lookup(string title, string userId)
        {
            SQLDataAccess sql = new SQLDataAccess();
            return sql.LoadData<int, dynamic>("dbo.spRecipe_Lookup", new { Title = title, UserId = userId }, "MMFoodData").FirstOrDefault();
        }
    }
}
