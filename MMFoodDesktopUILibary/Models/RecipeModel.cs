using MMFoodDesktopUILibary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFoodDesktopUILibrary.Models
{
    public class RecipeModel 
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public CategoryModel Category { get; set; }
        public List<RecipeIngredientModel> RecipeIngredients { get; set; }
        public List<RecipeStepModel> Steps { get; set; }        
        public DateTime CreateDate { get; set; }
        public DateTime LastModify { get; set; }
        public bool IPublished { get; set; }
    }
}
