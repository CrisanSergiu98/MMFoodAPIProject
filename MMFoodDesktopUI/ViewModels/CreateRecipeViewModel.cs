using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMFoodDesktopUILibrary.Api;
using MMFoodDesktopUILibary.Api;
using System.Net;
using MMFoodDesktopUILibrary.Models;

namespace MMFoodDesktopUI.ViewModels
{
    public class CreateRecipeViewModel: Screen
    {
        private ICategoryEndPoint _categoryEndPoint;
        private IRecipeEndPoint _recipeEndpoint;

        private RecipeModel _recipe;
        private BindingList<CategoryModel> _categories;
        
        public string PictureUrl
        {
            get { return _recipe.PictureUrl; }
            set
            {
                _recipe.PictureUrl = value;
                NotifyOfPropertyChange(() => PictureUrl);
            }
        }
        
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
        
        public BindingList<CategoryModel> Categories
        {
            get 
            {
                return _categories;
            }
            set
            {
                _categories = value;
                NotifyOfPropertyChange(() => Categories);
            }
        }

        private CategoryModel _selectedCategory;

        public CategoryModel SelectedCategory
            
        {
            get 
            { 
                return _selectedCategory;
            }
            set 
            { 
                _selectedCategory = value;
                NotifyOfPropertyChange(() => SelectedCategory);
            }
        }       


        public CreateRecipeViewModel(ICategoryEndPoint categoryEndPoint, IRecipeEndPoint recipeEndpoint)
        {            
            _categoryEndPoint = categoryEndPoint;
            _recipeEndpoint = recipeEndpoint;

            _recipe = new RecipeModel();
            _recipe.Ingredients = new List<IngredientModel>();
            _recipe.Steps = new List<RecipeStepModel>();
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadCategories();
        }

        private async Task LoadCategories()
        {
            var categoryList = await _categoryEndPoint.GetAll();
            Categories = new BindingList<CategoryModel>(categoryList);
        }

        private async Task SaveRecipe(RecipeModel recipe)
        {
            //if (ValidateRecipe(recipe))
            if (true)
            {
                await _recipeEndpoint.PostRecipe(_recipe);
            }
        }
        private bool CanPublish(RecipeModel recipe)
        {
            var output = true;

            if (recipe.Ingredients == null)
                output = false;
            if (recipe.Ingredients.Count == 0)
                output = false;

            if (recipe.Title == null)
                output = false;
            if (recipe.Title == "")
                output = false;

            if (recipe.Description == null)
                output = false;
            if (recipe.Description == "")
                output = false;

            if (recipe.Steps == null)
                output = false;
            if (recipe.Steps.Count == 0)
                output = false;

            if (PictureUrlCheck(PictureUrl))
                output = false;

            return output;
        }

        private bool CanSave(RecipeModel recipe)
        {
            bool output = true;
            return output;
        }

        private bool PictureUrlCheck(string url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("url");
            request.Method = "HEAD";

            try
            {
                request.GetResponse();
                return true;
            }
            catch
            {
                return false;
            }
        }        

        public void PublishRecipe()
        {

        }

        public void AddIngredientToRecipe()
        {
            var output = new IngredientModel();
            //output.Name = "";
            //output.Quantity = "";

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

        
    }
}
