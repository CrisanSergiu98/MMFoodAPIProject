using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MMFoodDesktopUI.Models
{
    public class PictureDisplayModel : INotifyPropertyChanged
    { 
        private string _url;

        public string Url
        {
            get { return _url; }
            set
            {
                _url = value;
                CallPropertyChanged(nameof(Url));
                CallPropertyChanged(nameof(DisplayUrl));
            }
        }

        public string DisplayUrl
        {
            get 
            {
                if (IsUrlValid)
                {
                    return _url;
                }
                else
                {
                    return ConfigurationManager.AppSettings["RecipePictureUrlPlaceholder"];
                }
            }
            
        }

        public bool IsUrlValid
        {
            get 
            {
                bool output = true;

                if (!PictureUrlCheck(_url))
                {
                    output = false;
                }

                return output;
            }           
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void CallPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool PictureUrlCheck(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
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
            catch
            {
                return false;
            }
        }
    }
}
