using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFoodDesktopUI.Models
{
    public class RecipeModel: PropertyChangedBase 
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public List<IngredientModel> Ingredients { get; set; }
        public List<RecipeStepModel> Steps { get; set; }
    }
}
