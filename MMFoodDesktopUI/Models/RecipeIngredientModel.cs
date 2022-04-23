using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFoodDesktopUI.Models
{
    public class RecipeIngredientModel
    {
        public int RecipeId { get; set; }
        public int QuanityId { get; set; }
        public int UnitId { get; set; }
        public int IngredientId { get; set; }
        public IngredientModel Ingredient { get; set; }
        public QuantityModel Quantity { get; set; }
        public UnitModel Unit { get; set; }
    }
}
