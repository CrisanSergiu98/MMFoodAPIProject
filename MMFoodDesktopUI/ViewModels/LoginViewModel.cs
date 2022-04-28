using Caliburn.Micro;
using MMFoodDesktopUI.EventModels;
using MMFoodDesktopUI.Helper;
using MMFoodDesktopUILibrary.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MMFoodDesktopUI.ViewModels
{
    public class LoginViewModel: Screen
    {
        //private string _username = "";
        //private string _password;

        private string _username = "test@test.com";
        private string _password = "Password1.";


        private string _errorMessage;

        /// <summary>
        /// Dependency Injection for our apiHelper
        /// </summary>
        private IAPIHelper _apiHelper;
        private IEventAggregator _events;

        public LoginViewModel(IAPIHelper apiHelper, IEventAggregator events)
        {
            _events = events;
            _apiHelper = apiHelper;
        }
        /// <summary>
        /// Capture the Username TextBox Text in this fullprop
        /// </summary>
        public string Username
        {
            get { return _username; }
            set 
            {
                _username = value;
                NotifyOfPropertyChange(()=> Username );
                NotifyOfPropertyChange(() => CanLogin);               
            }
        }
        /// <summary>
        /// Capture the Password PaswordBox Text in this fullprop
        /// </summary>
        public string Password
        {
            get { return _password; }
            set 
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogin);                
            }
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

        /// <summary>
        /// Capture the ErrorMessage TextBlock in this fullprop
        /// </summary>
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set 
            {
                _errorMessage = value;
                NotifyOfPropertyChange(()=> ErrorMessage);
                NotifyOfPropertyChange(() => IsErrorVisible);
            }
        }
        /// <summary>
        /// A prop to give our NotifyOfPropertyChange(() => CanLogin) so the Login Button activates only if CanLigin is true
        /// </summary>
        public bool CanLogin { 
            get
            {
                bool output = false;

                try
                {
                    if (Username.Length > 0 && Password?.Length > 6)
                    {
                        output = true;
                    }
                }
                catch
                {
                    _password = "";
                    if (Username.Length > 0 && Password.Length > 6)
                    {
                        output = true;
                    }
                }
                return output;
            }
        }

        /// <summary>
        /// Calls our apiHelper Authenticate Task
        /// </summary>
        /// <returns></returns>
        public async Task Login()
        {
            try
            {
                ErrorMessage = "";

                var result = await _apiHelper.Authenticate(Username, Password);

                await _apiHelper.GetLogedinUserInfo(result.access_token);

                _events.PublishOnUIThread(new LogOnEvent());
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;                
            }
        }
    }
}
