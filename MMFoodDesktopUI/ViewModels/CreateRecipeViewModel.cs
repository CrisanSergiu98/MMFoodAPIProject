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
        private IIngredientEndPoint _ingredientEndPoint;

        private IngredientModel _selectedIngredient;
        private RecipeModel _recipe;
        private BindingList<CategoryModel> _categories;
        private CategoryModel _selectedCategory;

        public string PictureUrl
        {
            get { return _recipe.PictureUrl; }
            set
            {
                _recipe.PictureUrl = value;
                NotifyOfPropertyChange(() => PictureUrl);
            }
        }
        
        public BindingList<RecipeIngredientModel> RecipeIngredients 
        {
            get
            {
                BindingList<RecipeIngredientModel> output = new BindingList<RecipeIngredientModel>(_recipe.RecipeIngredients);                
                return output ;
            }
            set
            {
                foreach(var i in value)
                {
                    _recipe.RecipeIngredients.Add(i);
                    NotifyOfPropertyChange(() => RecipeIngredients);
                    NotifyOfPropertyChange(() => SelectedIngredient);
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

        public IngredientModel SelectedIngredient
        {
            get 
            { 
                return _selectedIngredient;
            }
            set 
            { 
                _selectedIngredient = value;
                NotifyOfPropertyChange(() => SelectedIngredient);
            }
        }

        private BindingList<IngredientModel> _searchIngredientResult;
        public BindingList<IngredientModel> SearchIngredientResult
        {
            get { return _searchIngredientResult; }
            set { _searchIngredientResult = value; }
        }

        public CreateRecipeViewModel(ICategoryEndPoint categoryEndPoint, IRecipeEndPoint recipeEndpoint, IIngredientEndPoint ingredientEndPoint)
        {            
            _categoryEndPoint = categoryEndPoint;
            _recipeEndpoint = recipeEndpoint;
            _ingredientEndPoint = ingredientEndPoint;

            _recipe = new RecipeModel();
            _recipe.RecipeIngredients = new List<RecipeIngredientModel>();
            _recipe.Steps = new List<RecipeStepModel>();
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            //await LoadCategories();
        }
        private async void SearchForIngredients(string name)
        {
            SearchIngredientResult = new BindingList<IngredientModel>( await _ingredientEndPoint.GetFirstTenIngredients(SelectedIngredient.Name));            
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
        private async Task LoadCategories()
        {
            var categoryList = await _categoryEndPoint.GetAll();
            Categories = new BindingList<CategoryModel>(categoryList);
        }
        public async Task SaveRecipe()
        {
            await SaveTestRecipe();
        }
        public async Task SaveTestRecipe()
        {
            _recipe = new RecipeModel();
            _recipe.Title = "Test Recipe";
            _recipe.Description = "Test Description";
            _recipe.PictureUrl = "Test PictureUrl";
            _recipe.Category = new CategoryModel
            {
                Name = "Test Recipe Category",
                Description = "Test Recipe Category Description",
                PictureUrl="Test Recipe Category PictureUrl"
            };
            _recipe.RecipeIngredients = new List<RecipeIngredientModel>();
            _recipe.RecipeIngredients.Add(new RecipeIngredientModel
            {
                Ingredient = new IngredientModel
                {
                    Name = "Test Ingredient",
                    Description = "Test Ingredient Description",
                    Category = new IngredientCategoryModel
                    {
                        Name = "Test Ingredient Category"
                    }
                },

                Quantity = 10,
                Unit = "Kg"
            });
            _recipe.Steps = new List<RecipeStepModel>();
            _recipe.Steps.Add(new RecipeStepModel { Title = "TestStep", Number = 1 , Details="Test Step Details"});

            await _recipeEndpoint.PostRecipe(_recipe);
        }        
        public void AddIngredientToRecipe()
        {
            var output = new RecipeIngredientModel();
            output.Ingredient = new IngredientModel();
            //output.Name = "";
            //output.Quantity = "";

            RecipeIngredients.Add(output);
            NotifyOfPropertyChange(() =>RecipeIngredients);
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
