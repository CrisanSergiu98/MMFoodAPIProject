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
            SelectedIngredient = new RecipeIngredientDisplayModel(_ingredientEndPoint);
            SelectedIngredient.Ingredient = new IngredientDisplayModel();

            CategorySearchResult = new BindingList<CategoryDisplayModel>();
            IngredientSearchResult = new BindingList<IngredientDisplayModel>();
            ToAddIngredient = new IngredientDisplayModel();

            SelectedCategory.PropertyChanged += SelectedCategory_PropertyChanged;
            ToAddIngredient.PropertyChanged += ToAddIngredient_PropertyChanged;
            SelectedIngredient.Ingredient.PropertyChanged += Ingredient_PropertyChanged;
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

        private async void Ingredient_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var searchResult = await _ingredientEndPoint.SearchByName(SelectedIngredient.Ingredient.Name);

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
            //var searchResult = _categoryEndPoint.SearchByName(SelectedCategory.Name);

            var searchResult = await _categoryEndPoint.SearchByName(SelectedCategory.Name);

            //var result = _mapper.Map<List<CategoryDisplayModel>>(searchResult);
            List<CategoryDisplayModel> result = new List<CategoryDisplayModel>();

            foreach (var i in searchResult)
            {
                result.Add(new CategoryDisplayModel
                {
                    Name = i.Name,
                    Description = i.Description,
                    PictureUrl = i.PictureUrl
                });
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


        #endregion

        #region Public Methods

        public void AddIngredientToRecipe()
        {
            var output = new RecipeIngredientDisplayModel(_ingredientEndPoint);
            output.Ingredient = new IngredientDisplayModel();
            //output.Name = "";
            //output.Quantity = "";

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
        public async Task SaveRecipe()
        {
            //
        }

        #endregion
    }
}
