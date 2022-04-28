using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFoodDataManagerLibrary.Models
{
    public class StepDBModel
    {
        public int Id { get; set; }
        public int RecipeIde { get; set; }
        public int Number { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string PictureUrl { get; set; }
    }
}
