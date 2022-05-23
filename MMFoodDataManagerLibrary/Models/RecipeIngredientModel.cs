using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFoodDataManagerLibrary.Models
{
    public class RecipeIngredientModel
    {
        public int RecipeId { get; set; }
        public IngredientModel Ingredient { get; set; }
        public float Quantity { get; set; }
        public string Unit { get; set; }
        public bool IsReqired { get; set; }
    }
}
