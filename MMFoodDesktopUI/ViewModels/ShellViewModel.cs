using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFoodDesktopUI.ViewModels
{
    public class ShellViewModel: Conductor<object>
    {
        private LoginViewModel _loginVM;
        private CreateRecipeViewModel _createRecpieVM;

        public ShellViewModel(LoginViewModel loginVM, CreateRecipeViewModel createRecipeVM)
        {
            _loginVM = loginVM;
            _createRecpieVM = createRecipeVM;
            ActivateItem(_createRecpieVM);
        }

    }
}
