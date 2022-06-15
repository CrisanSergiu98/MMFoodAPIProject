using Caliburn.Micro;
using MMFoodDesktopUI.EventModels;
using MMFoodDesktopUILibary.Models;
using MMFoodDesktopUILibrary.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFoodDesktopUI.ViewModels
{
    public class ShellViewModel: Conductor<object>, IHandle<LogOnEvent>, IHandle<RegisterEvent>
    {        
        private CreateRecipeViewModel _createRecpieVM;
        private IEventAggregator _events;
        private ILoggedInUserModel _user;
        private IAPIHelper _apiHelper;

        public bool IsLoggedIn 
        {
            get
            {
                bool output = false;

                if (string.IsNullOrWhiteSpace(_user.Token) == false)
                {
                    output = true;
                }

                return output;
            }
        }

        public ShellViewModel(CreateRecipeViewModel createRecipeVM, IEventAggregator events, ILoggedInUserModel user, IAPIHelper apiHelper, LoginViewModel loginVM)
        {
            _events = events;
            _createRecpieVM = createRecipeVM;
            _user = user;
            _apiHelper = apiHelper;

            _events.Subscribe(this);

            ActivateItem(IoC.Get<LoginViewModel>());

        }

        

        public void ExitApplication()
        {
            TryClose();
        }

        public void LogOut()
        {
            _user.ResetUserModel();
            _apiHelper.LogOffUser();
            ActivateItem(IoC.Get<LoginViewModel>());
            NotifyOfPropertyChange(() => IsLoggedIn);
        }

        public void Register()
        {
            ActivateItem(IoC.Get<RegisterViewModel>());
        }


        #region Events
        public void Handle(RegisterEvent message)
        {
            ActivateItem(IoC.Get<LoginViewModel>());
            NotifyOfPropertyChange(() => IsLoggedIn);
        }

        public void Handle(LogOnEvent message)
        {
            ActivateItem(_createRecpieVM);
            NotifyOfPropertyChange(() => IsLoggedIn);
        }

        #endregion

    }
}
