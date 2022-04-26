using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFoodDesktopUI.Models
{
    public class IngredientModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descriptiona { get; set; }
        public string PictureUrl { get; set; }
        public string IngredientCategoryName { get; set; }
        public IngredientCategoryModel SelectedCategory { get; set; }
        public List<string> GetFirstTenMatching {
            get
            {
                return new List<string> { "potate", "tomato", "chicken stock", "test", "test" };
            }
        }
        public QuantityModel Quantity { get; set; }
        public UnitModel Unit { get; set; }

    }
}
