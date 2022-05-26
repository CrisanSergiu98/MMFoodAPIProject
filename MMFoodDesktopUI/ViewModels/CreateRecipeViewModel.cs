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

        private string _title;
        private string _description;
        private string _pictureUrl;
        private CategoryDisplayModel _selectedCategory;
        private BindingList<RecipeIngredientDisplayModel> _recipeIngredients;
        private BindingList<RecipeStepModel> _steps;
        private BindingList<CategoryDisplayModel> _categorySearchResult;
        private BindingList<IngredientDisplayModel> _ingredientSearchResult;
        private RecipeIngredientDisplayModel _selectedIngredient;
        private IngredientDisplayModel _toAddIngredient;
        private RecipeIngredientDisplayModel _toAddRecipeIngredient;
        private PictureDisplayModel _picture;

        #endregion

        #region Properties        

        #region Binging

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                TitleError.Initialize();
                NotifyOfPropertyChange(() => Title);
            }
        }        
        public PictureDisplayModel Picture
        {
            get { return _picture; }
            set 
            { 
                _picture = value;
                NotifyOfPropertyChange(() => Picture);
            }
        }
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                DescriptionError.Initialize();
                NotifyOfPropertyChange(() => Description);
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
                CategoryError.Initialize();
                NotifyOfPropertyChange(() => SelectedCategory);
                NotifyOfPropertyChange(() => CategorySearchResult);
            }
        }
        public BindingList<RecipeIngredientDisplayModel> RecipeIngredients
        {
            get { return _recipeIngredients; }
            set
            {
                _recipeIngredients = value;
                IngredientsError.Initialize();
                NotifyOfPropertyChange(() => RecipeIngredients);
            }
        }
        public RecipeIngredientDisplayModel ToAddRecipeIngredient
        {
            get { return _toAddRecipeIngredient; }
            set
            {
                _toAddRecipeIngredient = value;
                ToAddIngredientError.Initialize();
                NotifyOfPropertyChange(() => ToAddRecipeIngredient);
            }
        }
        public BindingList<RecipeStepModel> Steps
        {
            get { return _steps; }
            set
            {
                _steps = value;
                StepsError.Initialize();
                NotifyOfPropertyChange(() => Steps);
            }
        }

        #endregion

        #region Logic

        public BindingList<IngredientDisplayModel> IngredientSearchResult
        {
            get { return _ingredientSearchResult; }
            set
            {
                _ingredientSearchResult = value;
                NotifyOfPropertyChange(() => IngredientSearchResult);
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
        public IngredientDisplayModel ToAddIngredient
        {
            get { return _toAddIngredient; }
            set
            {
                _toAddIngredient = value;
                NotifyOfPropertyChange(() => ToAddIngredient);
            }
        }

        #endregion

        #region ErrorMessages

        private ErrorDisplayModel _toAddIngredientError;

        public ErrorDisplayModel ToAddIngredientError
        {
            get { return _toAddIngredientError; }
            set
            {
                _toAddIngredientError = value;
                NotifyOfPropertyChange(() => ToAddIngredientError);
            }
        }

        private ErrorDisplayModel _titleError;

        public ErrorDisplayModel TitleError
        {
            get { return _titleError; }
            set 
            { 
                _titleError = value;
                NotifyOfPropertyChange(() => TitleError);
            }
        }        

        private ErrorDisplayModel _descriptionError;

        public ErrorDisplayModel DescriptionError
        {
            get { return _descriptionError; }
            set 
            {
                _descriptionError = value;
                NotifyOfPropertyChange(() => DescriptionError);
            }
        }

        private ErrorDisplayModel _pictureError;

        public ErrorDisplayModel PictureError
        {
            get { return _pictureError; }
            set 
            {
                _pictureError = value;
                NotifyOfPropertyChange(() => PictureError);
            }
        }

        private ErrorDisplayModel _categoryError;

        public ErrorDisplayModel CategoryError
        {
            get { return _categoryError; }
            set 
            { 
                _categoryError = value;
                NotifyOfPropertyChange(() => CategoryError);
            }
        }

        private ErrorDisplayModel _ingredientsError;

        public ErrorDisplayModel IngredientsError
        {
            get { return _ingredientsError; }
            set 
            {
                _ingredientsError = value;
                NotifyOfPropertyChange(() => IngredientsError);
            }
        }

        private ErrorDisplayModel _stepsError;

        public ErrorDisplayModel StepsError
        {
            get { return _stepsError; }
            set 
            { 
                _stepsError = value;
                NotifyOfPropertyChange(() => StepsError);
            }
        }

        #endregion

        #endregion

        #region Constructor()

        public CreateRecipeViewModel(ICategoryEndPoint categoryEndPoint, IRecipeEndPoint recipeEndpoint,
            IIngredientEndPoint ingredientEndPoint, IMapper mapper)
        {
            #region Dependency Injection

            _categoryEndPoint = categoryEndPoint;
            _recipeEndpoint = recipeEndpoint;
            _ingredientEndPoint = ingredientEndPoint;
            _mapper = mapper;

            #endregion            

            #region ErrorMessagesInitialization

            _toAddIngredientError = new ErrorDisplayModel();
            _titleError = new ErrorDisplayModel();
            _descriptionError = new ErrorDisplayModel();
            _pictureError = new ErrorDisplayModel();
            _categoryError = new ErrorDisplayModel();
            _ingredientsError = new ErrorDisplayModel();
            _stepsError = new ErrorDisplayModel();

            #endregion

            #region Initialization

            RecipeIngredients = new BindingList<RecipeIngredientDisplayModel>();
            SelectedCategory = new CategoryDisplayModel();
            SelectedIngredient = new RecipeIngredientDisplayModel();
            SelectedIngredient.Ingredient = new IngredientDisplayModel();

            CategorySearchResult = new BindingList<CategoryDisplayModel>();
            IngredientSearchResult = new BindingList<IngredientDisplayModel>();
            _toAddIngredient = new IngredientDisplayModel();
            _toAddRecipeIngredient = new RecipeIngredientDisplayModel();
            Steps = new BindingList<RecipeStepModel>();
            _picture = new PictureDisplayModel();

            #endregion

            #region Value Settings

            Title = "Your recipe title...";
            Description = "Your recipe description...";

            #endregion

            #region Events Configuration

            SelectedCategory.PropertyChanged += SelectedCategory_PropertyChanged;
            ToAddIngredient.PropertyChanged += ToAddIngredient_PropertyChanged;

            #endregion
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
                    Id=i.Id,
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
            if (ValidateIngredient())
            {
                _toAddRecipeIngredient.Ingredient = _toAddIngredient;

                RecipeIngredients.Add(_toAddRecipeIngredient);

                NotifyOfPropertyChange(() => RecipeIngredients);
            }            
        }
        
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
            RecipeModel toSaveRecipe = new RecipeModel();

            toSaveRecipe.Title = Title;
            toSaveRecipe.Description = Description;
            toSaveRecipe.PictureUrl = Picture.Url;

            toSaveRecipe.Category = ModelConvertor.FromCategoryDisplayToModel(SelectedCategory);

            toSaveRecipe.RecipeIngredients = new List<RecipeIngredientModel>();
            toSaveRecipe.Steps = new List<RecipeStepModel>();

            foreach(var i in RecipeIngredients)
            {
                toSaveRecipe.RecipeIngredients.Add(ModelConvertor.FromRecipeIngredientDisplayToModel(i)); 
            }

            foreach(var i in Steps)
            {
                toSaveRecipe.Steps.Add(i);
            }

            if (ValidateRecipe())
            {
                //await _recipeEndpoint.PostRecipe(toSaveRecipe);
            }
        }

        #endregion

        #region Private Methods        

        private bool ValidateRecipe()
        {
            bool output = true;

            TitleError.Initialize();
            DescriptionError.Initialize();
            PictureError.Initialize();
            StepsError.Initialize();

            if (Title.Length <= 0)
            {
                output = false;
                TitleError.ErrorMessage = "Invalid Title";
            }
                

            if (Description.Length <= 0)
            {
                output = false;
                DescriptionError.ErrorMessage = "Invalid Description";
            }
                

            if (!Picture.IsUrlValid)
            {
                output = false;
                PictureError.ErrorMessage = "Invalid Picture";
            }
                
            if(SelectedCategory==null || SelectedCategory.Id == 0)
            {
                output = false;
                CategoryError.ErrorMessage = "You must select a valid category";
            }

            if (RecipeIngredients.Count <= 0)
            {
                output = false;
                IngredientsError.ErrorMessage = "You need at least one ingredient";
            }
                

            if (Steps.Count <= 0)
            {
                output = false;
                StepsError.ErrorMessage = "You need at least one step";
            }                

            return output;
        }

        private bool ValidateIngredient()
        {
            bool output = true;
            ToAddIngredientError.ErrorMessage = "";

            if (ToAddRecipeIngredient.Unit.Length == 0)
            {
                output = false;
                ToAddIngredientError.ErrorMessage = "Unit not specified";
            }

            if (ToAddRecipeIngredient.Quantity == 0)
            {
                output = false;
                ToAddIngredientError.ErrorMessage = "Quantity has to be bigger than 0";
            }

            try
            {
                if (_toAddIngredient.Id == 0)
                {
                    output = false;
                    ToAddIngredientError.ErrorMessage = "You have to select an ingredient from the list";
                }
            }
            catch (NullReferenceException e)
            {
                output = false;

                _toAddIngredient = new IngredientDisplayModel();
                ToAddIngredientError.ErrorMessage = "You have to select an ingredient from the list";
            }

            return output;
        }

        #endregion
    }
}
