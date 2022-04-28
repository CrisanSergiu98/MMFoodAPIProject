using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFoodDesktopUILibrary.Models
{
    public class IngredientModel
    {
        public string Name { get; set; }
        public string Descriptiona { get; set; }
        public string PictureUrl { get; set; }
        public IngredientCategoryModel SelectedCategory { get; set; }
        public List<string> GetFirstTenMatching {
            get
            {
                return new List<string> { "potate", "tomato", "chicken stock", "test", "test" };
            }
        }
        public float Quantity { get; set; }
        public string Unit { get; set; }

    }
}
