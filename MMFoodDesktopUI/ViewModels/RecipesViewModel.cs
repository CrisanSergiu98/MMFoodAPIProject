using Caliburn.Micro;
using MMFoodDesktopUILibary.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFoodDesktopUI.ViewModels
{
    public class RecipesViewModel: Screen
    {
        #region Dependency Injection

        IRecipeEndPoint _recipeEndpoint;

        #endregion

        public RecipesViewModel(IRecipeEndPoint recipeEndpoint)
        {
            _recipeEndpoint = recipeEndpoint;
        }
    }
}
