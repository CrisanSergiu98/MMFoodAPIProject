using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFoodDesktopUILibary.Models
{
    public class CategoryModel
    {
        //Id, [Name], [Description], PictureURL
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureURL { get; set; }
    }
}
