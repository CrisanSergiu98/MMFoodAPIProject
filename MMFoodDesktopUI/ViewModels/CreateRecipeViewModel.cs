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

        #endregion

        #region Properties        

        #region Binging

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                NotifyOfPropertyChange(() => Title);
            }
        }
        public string PictureUrl
        {
            get { return _pictureUrl; }
            set
            {
                _pictureUrl = value;
                NotifyOfPropertyChange(() => PictureUrl);
            }
        }
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
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
                NotifyOfPropertyChange(() => RecipeIngredients);
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
        public BindingList<RecipeStepModel> Steps
        {
            get { return _steps; }
            set
            {
                _steps = value;
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



        #endregion

        #endregion

        #region Constructor()

        public CreateRecipeViewModel(ICategoryEndPoint categoryEndPoint, IRecipeEndPoint recipeEndpoint,
            IIngredientEndPoint ingredientEndPoint, IMapper mapper)
        {
            _categoryEndPoint = categoryEndPoint;
            _recipeEndpoint = recipeEndpoint;
            _ingredientEndPoint = ingredientEndPoint;
            _mapper = mapper;

            Title = "Your recipe title...";
            Description = "Your recipe description...";
            PictureUrl = "Picture URL...";

            RecipeIngredients = new BindingList<RecipeIngredientDisplayModel>();
            SelectedCategory = new CategoryDisplayModel();
            SelectedIngredient = new RecipeIngredientDisplayModel();
            SelectedIngredient.Ingredient = new IngredientDisplayModel();

            CategorySearchResult = new BindingList<CategoryDisplayModel>();
            IngredientSearchResult = new BindingList<IngredientDisplayModel>();
            _toAddIngredient = new IngredientDisplayModel();
            _toAddRecipeIngredient = new RecipeIngredientDisplayModel();            

            #region ErrorMessagesInitialization

            _toAddIngredientError = new ErrorDisplayModel();

            #endregion

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
            toSaveRecipe.PictureUrl = PictureUrl;

            toSaveRecipe.Category = ModelConvertor.FromCategoryDisplayToModel(SelectedCategory);

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

            if (Title.Length <= 0)
            {
                output = false;
            }
                

            if (Description.Length <= 0)
            {
                output = false;
            }
                

            if (PictureUrl.Length <= 0)
            {
                output = false;
            }
                

            if (RecipeIngredients.Count <= 0)
            {
                output = false;
            }
                

            if (RecipeIngredients.Count <= 0)
            {
                output = false;
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
