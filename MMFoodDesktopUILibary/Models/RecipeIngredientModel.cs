using MMFoodDesktopUILibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFoodDesktopUILibrary.Models
{
    public class RecipeIngredientModel
    {
        public int RecipeId { get; set; }
        public IngredientModel Ingredient { get; set; }
        public float Quantity { get; set; }
        public string Unit { get; set; }
    }
}
