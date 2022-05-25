using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFoodDataManagerLibrary.Models
{
    public class RecipeModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public CategoryModel Category { get; set; }
        public List<RecipeIngredientModel> RecipeIngredients { get; set; }
        public List<StepDBModel> Steps { get; set; }        
        public DateTime CreateDate { get; set; }
        public DateTime LastModify { get; set; }
        public bool IPublished { get; set; }
    }
}
