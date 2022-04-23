using Caliburn.Micro;
using MMFoodDesktopUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFoodDesktopUI.ViewModels
{
    public class CreateRecipeViewModel: Screen
    {
        private BindableCollection<RecipeIngredientModel> _recipeIngredients;
        private BindableCollection<RecipeStepModel> _steps;

        public BindableCollection<RecipeIngredientModel> RecipeIngredients
        {
            get { return _recipeIngredients; }
            set
            {
                _recipeIngredients = value;
                NotifyOfPropertyChange(() => RecipeIngredients);
            }
        }
        public BindableCollection<RecipeStepModel> Steps
        {
            get { return _steps; }
            set
            {
                _steps = value;
                NotifyOfPropertyChange(() => Steps);
            }
        }

        public CreateRecipeViewModel()
        {
            RecipeIngredients = new BindableCollection<RecipeIngredientModel>();
            Steps = new BindableCollection<RecipeStepModel>();
        }

        public void AddIngredientToRecipe()
        {
            var output = new RecipeIngredientModel();

            output.Ingredient = new IngredientModel();
            output.Quantity = new QuantityModel();
            output.Unit = new UnitModel();

            RecipeIngredients.Add(output);

            NotifyOfPropertyChange(() => RecipeIngredients);
        }

        public void AddStepToRecipe()
        {
            var output = new RecipeStepModel();

            output.Title = "Step Title";
            output.Number = Steps.Count() + 1;
            output.Details = "Step Details...";

            Steps.Add(output);
            NotifyOfPropertyChange(() => Steps);
        }
    }
}
