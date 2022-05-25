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
using AutoMapper;
using MMFoodDesktopUI.Models;
using MMFoodDesktopUI.Helper;

namespace MMFoodDesktopUI.ViewModels
{
    public class CreateRecipeViewModel: Screen
    {
        #region Dependency Injection

        private ICategoryEndPoint _categoryEndPoint;
        private IRecipeEndPoint _recipeEndpoint;
        private IIngredientEndPoint _ingredientEndPoint;
        private IMapper _mapper;

        #endregion

        #region Backing Fields
        
        private CategoryDisplayModel _selectedCategory;
        private BindingList<RecipeIngredientDisplayModel> _recipeIngredients;
        private BindingList<RecipeStepModel> _steps;
        private BindingList<CategoryDisplayModel> _categorySearchResult;
        private BindingList<IngredientDisplayModel> _ingredientSearchResult;
        private RecipeIngredientDisplayModel _selectedIngredient;
        private IngredientDisplayModel _toAddIngredient;
        private RecipeIngredientDisplayModel _toAddRecipeIngredient;

        #endregion

        #region Properties

        public BindingList<RecipeIngredientDisplayModel> RecipeIngredients
        {
            get { return _recipeIngredients; }
            set
            {
                _recipeIngredients = value;
                NotifyOfPropertyChange(() => RecipeIngredients);
            }
        }

        public BindingList<RecipeStepModel> Steps
        {
            get { return _steps; }
            set
            {
                _steps = value;
                NotifyOfPropertyChange(() => Steps);
            }
        }

        public BindingList<CategoryDisplayModel> CategorySearchResult
        {
            get
            {           
                return _categorySearchResult;
            }
            set
            {
                _categorySearchResult = value;
                NotifyOfPropertyChange(() => CategorySearchResult);
            }
        }        

        public BindingList<IngredientDisplayModel> IngredientSearchResult
        {
            get { return _ingredientSearchResult; }
            set 
            {
                _ingredientSearchResult = value;
                NotifyOfPropertyChange(() => IngredientSearchResult);
            }
        }

        public CategoryDisplayModel SelectedCategory
        {
            get
            {
                return _selectedCategory;
            }
            set
            {
                _selectedCategory = value;
                NotifyOfPropertyChange(() => SelectedCategory);
                NotifyOfPropertyChange(() => CategorySearchResult);
            }
        }        

        public RecipeIngredientDisplayModel SelectedIngredient
        {
            get { return _selectedIngredient; }
            set 
            { 
                _selectedIngredient = value;
                NotifyOfPropertyChange(() => SelectedIngredient);
                NotifyOfPropertyChange(() => IngredientSearchResult);
                NotifyOfPropertyChange(() => ToAddIngredient);
            }
        }        

        public IngredientDisplayModel ToAddIngredient
        {
            get { return _toAddIngredient; }
            set 
            {
                _toAddIngredient = value;
                NotifyOfPropertyChange(() => ToAddIngredient);
            }
        }        

        public RecipeIngredientDisplayModel ToAddRecipeIngredient
        {
            get { return _toAddRecipeIngredient; }
            set
            {
                _toAddRecipeIngredient = value;
                NotifyOfPropertyChange(() => ToAddRecipeIngredient);
            }
        }

        #endregion

        #region Constructor()

        public CreateRecipeViewModel(ICategoryEndPoint categoryEndPoint, IRecipeEndPoint recipeEndpoint,
            IIngredientEndPoint ingredientEndPoint, IMapper mapper)
        {
            _categoryEndPoint = categoryEndPoint;
            _recipeEndpoint = recipeEndpoint;
            _ingredientEndPoint = ingredientEndPoint;
            _mapper = mapper;            

            RecipeIngredients = new BindingList<RecipeIngredientDisplayModel>();
            SelectedCategory = new CategoryDisplayModel();
            SelectedIngredient = new RecipeIngredientDisplayModel();
            SelectedIngredient.Ingredient = new IngredientDisplayModel();

            CategorySearchResult = new BindingList<CategoryDisplayModel>();
            IngredientSearchResult = new BindingList<IngredientDisplayModel>();
            _toAddIngredient = new IngredientDisplayModel();
            _toAddRecipeIngredient = new RecipeIngredientDisplayModel();

            SelectedCategory.PropertyChanged += SelectedCategory_PropertyChanged;
            ToAddIngredient.PropertyChanged += ToAddIngredient_PropertyChanged;
        }

        #endregion

        #region Events

        private async void ToAddIngredient_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var searchResult = await _ingredientEndPoint.SearchByName(ToAddIngredient.Name);

            List<IngredientDisplayModel> result = new List<IngredientDisplayModel>();

            foreach (var i in searchResult)
            {
                result.Add(new IngredientDisplayModel
                {
                    Name = i.Name,
                    PictureUrl = i.PictureUrl,
                    Description = i.Description
                });
            }

            IngredientSearchResult = new BindingList<IngredientDisplayModel>(result);
        }        

        private async void SelectedCategory_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var searchResult = await _categoryEndPoint.SearchByName(SelectedCategory.Name);

            List<CategoryDisplayModel> result = new List<CategoryDisplayModel>();

            foreach (var i in searchResult)
            {
                result.Add(ModelConvertor.FromCategoryModelToDisplay(i));
            }

            CategorySearchResult = new BindingList<CategoryDisplayModel>(result);
            NotifyOfPropertyChange(() => CategorySearchResult);
        }

        #endregion

        #region Override
        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            //await LoadCategories();
        }

        #endregion        

        #region Public Methods

        public void AddIngredientToRecipe()
        {
            _toAddRecipeIngredient.Ingredient = _toAddIngredient;

            RecipeIngredients.Add(_toAddRecipeIngredient);

            

            NotifyOfPropertyChange(() => RecipeIngredients);
        }

        /// <summary>
        /// Edit Ingredient Button
        /// </summary>
        public void EditIngredient()
        {
            ToAddRecipeIngredient.Ingredient = SelectedIngredient.Ingredient;
            ToAddRecipeIngredient.Quantity = SelectedIngredient.Quantity;
            ToAddRecipeIngredient.Unit = SelectedIngredient.Unit;


            NotifyOfPropertyChange(() => ToAddRecipeIngredient);

            RecipeIngredients.Remove(SelectedIngredient);
        }

        /// <summary>
        /// Remove Ingredient Button
        /// </summary>
        public void RemoveIngredient()
        {
            RecipeIngredients.Remove(SelectedIngredient);
        }

        public void AddStepToRecipe()
        {
            var output = new RecipeStepModel();
            
            output.Number = Steps.Count() + 1;
            output.Details = "Step Details...";

            Steps.Add(output);
            NotifyOfPropertyChange(() => Steps);
        }
        public async Task SaveRecipe()
        {
            var toSaveRecipe = new RecipeModel();

            toSaveRecipe.Category = ModelConvertor.FromCategoryDisplayToModel(SelectedCategory);

            await _recipeEndpoint.PostRecipe(toSaveRecipe);
        }

        #endregion

        #region Private Methods

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

        private bool ValidateRecipe()
        {
            bool output = true;
            return output;
        }

        #endregion
    }
}
