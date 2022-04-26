using Caliburn.Micro;
using MMFoodDesktopUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMFoodDesktopUILibrary.Api;

namespace MMFoodDesktopUI.ViewModels
{
    public class CreateRecipeViewModel: Screen
    {
        private IAPIHelper _apiHelper;
        /// <summary>
        /// This will be our backing field for pretty much evrything and we are goign to pass this along when we do the recording of the recipe
        /// </summary>
        private RecipeModel _recipe;
        private BindingList<RecipeCategoryModel> _categories;

        /// <summary>
        /// Property that gets and sents for the _recipe.
        /// We bind our UI with this property and they act like a middle man between the _recipe and the user info
        /// </summary>
        public string PictureUrl
        {
            get { return _recipe.PictureUrl; }
            set
            {
                _recipe.PictureUrl = value;
                NotifyOfPropertyChange(() => PictureUrl);
            }
        }
        /// <summary>
        /// Property that gets and sents for the _recipe.
        /// We bind our UI with this property and they act like a middle man between the _recipe and the user info
        /// </summary>
        public BindingList<IngredientModel> Ingredients 
        {
            get
            {
                BindingList<IngredientModel> output = new BindingList<IngredientModel>(_recipe.Ingredients);                
                return output ;
            }
            set
            {
                foreach(var i in value)
                {
                    _recipe.Ingredients.Add(i);
                    NotifyOfPropertyChange(() => Ingredients);
                }
            }
        }

        /// <summary>
        /// Property that gets and sents for the _recipe.
        /// We bind our UI with this property and they act like a middle man between the _recipe and the user info
        /// </summary>
        public BindingList<RecipeStepModel> Steps
        {
            get
            {
                BindingList<RecipeStepModel> output = new BindingList<RecipeStepModel>(_recipe.Steps);
                return output;
            }
            set
            {
                foreach (var i in value)
                {
                    _recipe.Steps.Add(i);
                }
            }
        }

        /// <summary>
        /// Full Prop that gets the categories from the api
        /// </summary>
        public BindingList<RecipeCategoryModel> Categories
        {
            get 
            {
                return _categories;
            }
            set
            {
                _categories = value;
            }
        }

        public CreateRecipeViewModel(IAPIHelper aPIHelper)
        {
            _apiHelper = aPIHelper;
            //get categories from API
            _recipe = new RecipeModel();
            _recipe.PictureUrl = "your Url";
            _recipe.Ingredients = new List<IngredientModel>();
            _recipe.Steps = new List<RecipeStepModel>();
        }

        public void SaveRecipe()
        {

        }

        public void PublishRecipe()
        {

        }

        public void AddIngredientToRecipe()
        {
            var output = new IngredientModel();
            output.Name = "";
            output.Quantity = new QuantityModel();
            output.Unit = new UnitModel();

            Ingredients.Add(output);
            NotifyOfPropertyChange(() =>Ingredients);
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

        private void Save()
        {

        }
        private void SaveAndPublish()
        {

        }
    }
}
