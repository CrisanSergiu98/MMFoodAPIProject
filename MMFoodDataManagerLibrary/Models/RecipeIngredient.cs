using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFoodDataManagerLibrary.Models
{
    public class RecipeIngredient
    {
        public IngredientModel Ingredient { get; set; }
        public float Quantity { get; set; }
        public IngredientCategory Category { get; set; }
        public string Unit { get; set; }
    }
}
