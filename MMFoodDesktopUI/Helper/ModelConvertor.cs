using MMFoodDesktopUI.Models;
using MMFoodDesktopUILibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFoodDesktopUI.Helper
{
    public static class ModelConvertor
    {
        #region Category
        public static CategoryModel FromCategoryDisplayToModel(CategoryDisplayModel input)
        {
            var output = new CategoryModel
            {
                Id = input.Id,
                Name = input.Name,
                Description = input.Description,
                PictureUrl = input.PictureUrl
            };
            return output;
        }

        public static CategoryDisplayModel FromCategoryModelToDisplay(CategoryModel input)
        {
            var output = new CategoryDisplayModel
            {
                Id = input.Id,
                Name = input.Name,
                Description = input.Description,
                PictureUrl = input.PictureUrl
            };
            return output;
        }
        #endregion

        #region Ingredient
        public static IngredientModel FromIngredientDisplayToModel(IngredientDisplayModel input)
        {
            return new IngredientModel
            {
                Id = input.Id,
                Name = input.Name,
                Description = input.Description,
                PictureUrl = input.PictureUrl,
                Category = input.Category
            };
        }

        public static IngredientDisplayModel FromIngredientModelToDisplay(IngredientModel input)
        {
            return new IngredientDisplayModel
            {
                Id = input.Id,
                Name = input.Name,
                Description = input.Description,
                PictureUrl = input.PictureUrl,
                Category = input.Category
            };
        }
        #endregion

        #region RecipeIngredient
        public static RecipeIngredientModel FromIngredientDisplayToModel(RecipeIngredientDisplayModel input)
        {
            return new RecipeIngredientModel
            {
                RecipeId = input.RecipeId,
                Ingredient = FromIngredientDisplayToModel(input.Ingredient),
                Quantity = input.Quantity,
                Unit = input.Unit
            };
        }

        public static RecipeIngredientDisplayModel FromRecipeIngredientModelToDisplay(RecipeIngredientModel input)
        {
            return new RecipeIngredientDisplayModel
            {
                RecipeId = input.RecipeId,
                Ingredient = FromIngredientModelToDisplay(input.Ingredient),
                Quantity = input.Quantity,
                Unit = input.Unit
            };
        }
        #endregion
    }
}
