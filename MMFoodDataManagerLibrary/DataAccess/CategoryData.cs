using MMFoodDataManagerLibrary.Internal.DataAccess;
using MMFoodDataManagerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFoodDataManagerLibrary.DataAccess
{
    public class CategoryData
    {
        public List<CategoryDBModel> GetAllCategories()
        {
            SQLDataAccess sql = new SQLDataAccess();
        
            var output = sql.LoadData<CategoryDBModel, dynamic>("dbo.spCategory_GetAll", new { }, "MMFoodData");

            return output;
        }
    }
}
