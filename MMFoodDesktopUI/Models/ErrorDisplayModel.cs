using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFoodDesktopUI.Models
{
    public class ErrorDisplayModel : INotifyPropertyChanged
    {
        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set 
            {
                _errorMessage = value;
                CallPropertyChanged(nameof(ErrorMessage));
                CallPropertyChanged(nameof(IsErrorVisible));
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

        public event PropertyChangedEventHandler PropertyChanged;
        private void CallPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Initialize()
        {
            ErrorMessage = "";
        }
    }
}
