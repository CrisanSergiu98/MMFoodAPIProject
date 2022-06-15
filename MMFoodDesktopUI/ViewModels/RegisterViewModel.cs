using Caliburn.Micro;
using MMFoodDesktopUI.EventModels;
using MMFoodDesktopUILibary.Api;
using MMFoodDesktopUILibary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFoodDesktopUI.ViewModels
{
    public class RegisterViewModel: Screen
    {
        #region DI

        IAccountEndPoint _accountEndPoint;
        IEventAggregator _events;

        #endregion

        #region Binding
        private string _username;

        public string Username
        {
            get { return _username; }
            set 
            { 
                _username = value;
                NotifyOfPropertyChange(() => Username);
            }
        }
        private string _email;

        public string Email
        {
            get { return _email; }
            set 
            { 
                _email = value;
                NotifyOfPropertyChange(() => Email);
            }
        }
        private string _password;

        public string Password
        {
            get { return _password; }
            set 
            { 
                _password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }
        private string _confirmPassword;

        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set 
            { 
                _confirmPassword = value;
                NotifyOfPropertyChange(() => ConfirmPassword);
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                NotifyOfPropertyChange(() => ErrorMessage);
                NotifyOfPropertyChange(() => IsErrorVisible);
            }
        }


        #endregion

        public RegisterViewModel(IAccountEndPoint accountEndPoint, IEventAggregator eventAggregator)
        {
            _accountEndPoint = accountEndPoint;
            _events = eventAggregator;
        }

        public bool IsErrorVisible
        {
            get
            {
                bool output = false;

                if (ErrorMessage?.Length > 0)
                    output = true;

                return output;
            }
        }

        public void Register()
        {
            RegisterBindingModel newUser = new RegisterBindingModel
            {
                Email = _email,
                Password = _password,
                ConfirmPassword = _confirmPassword
            };

            _accountEndPoint.CreateAccount(newUser);

            _events.PublishOnUIThread(new RegisterEvent());
        }
    }
}
