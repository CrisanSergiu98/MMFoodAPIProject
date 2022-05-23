using AutoMapper;
using MMFoodDesktopUILibary.Api;
using MMFoodDesktopUILibrary.Api;
using MMFoodDesktopUILibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFoodDesktopUI.Models
{
    public class CategoryDisplayModel : INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;

                CallPropertyChanged(nameof(Name));
            }
        }

        public string Description { get; set; }
        public string PictureUrl { get; set; }        

        public event PropertyChangedEventHandler PropertyChanged;
        private void CallPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
