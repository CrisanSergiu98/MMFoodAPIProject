using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFoodDesktopUI.Models
{
    public class RecipeIngredientDisplayModel: INotifyPropertyChanged
    {
        private IngredientDisplayModel _ingredient;
        private float _quantity = 0;
        private string _unit = "";

        public IngredientDisplayModel Ingredient
        {
            get { return _ingredient; }
            set 
            {
                _ingredient = value;
                CallPropertyChanged(nameof(Ingredient));
            }
        }        

        public float Quantity
        {
            get { return _quantity; }
            set 
            { 
                _quantity = value;
                CallPropertyChanged(nameof(Quantity));
            }
        }      

        public string Unit
        {
            get { return _unit; }
            set 
            { 
                _unit = value;
                CallPropertyChanged(nameof(Unit));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void CallPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
