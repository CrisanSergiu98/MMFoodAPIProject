using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using MMFoodDesktopUILibrary.Models;

namespace MMFoodDesktopUI.Models
{
    public class IngredientDisplayModel: INotifyPropertyChanged
    {
        public int Id { get; set; }

        private string _name = "";

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
        public IngredientCategoryModel Category { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void CallPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
