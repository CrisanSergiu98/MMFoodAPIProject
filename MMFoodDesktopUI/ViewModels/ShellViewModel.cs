﻿using Caliburn.Micro;
using MMFoodDesktopUI.EventModels;
using MMFoodDesktopUILibary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFoodDesktopUI.ViewModels
{
    public class ShellViewModel: Conductor<object>, IHandle<LogOnEvent>
    {        
        private CreateRecipeViewModel _createRecpieVM;
        private IEventAggregator _events;
        private ILoggedInUserModel _user;

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

        public ShellViewModel(CreateRecipeViewModel createRecipeVM, IEventAggregator events, ILoggedInUserModel user)
        {
            _events = events;
            _createRecpieVM = createRecipeVM;
            _user = user;

            _events.Subscribe(this);

            ActivateItem(IoC.Get<LoginViewModel>());

        }

        public void Handle(LogOnEvent message)
        {
            ActivateItem(_createRecpieVM);
            NotifyOfPropertyChange(() => IsLoggedIn);
        }

        public void ExitApplication()
        {
            TryClose();
        }

        public void LogOut()
        {
            _user.LoggOffUser();
            ActivateItem(IoC.Get<LoginViewModel>());
            NotifyOfPropertyChange(() => IsLoggedIn);
        }
    }
}
