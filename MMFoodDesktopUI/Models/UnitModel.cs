using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFoodDesktopUI.Models
{
    public class UnitModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> SearchResults 
        {
            get
            {
                return new List<string> { "kg", "tbs", "Tbs" };
            }
        }
    }
}
