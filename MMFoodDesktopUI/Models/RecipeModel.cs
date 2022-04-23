using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFoodDesktopUI.Models
{
    public class RecipeModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public BindableCollection<RecipeIngredientModel> RecipeIngredients { get; set; }
        public BindableCollection<RecipeStepModel> Steps { get; set; }
    }
}
