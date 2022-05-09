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
        //public CategoryDBModel SaveCategory(CategoryModel category)
        //{
        //    SQLDataAccess sql = new SQLDataAccess();

        //    CategoryDBModel dbCategory = new CategoryDBModel();

        //    dbCategory.Name = category.Name;

        //    try
        //    {
        //        dbCategory.Id = sql.LoadData<int, dynamic>("dbo.spCategory_Lookup", new { Name = dbCategory.Name }, "MMFoodData").FirstOrDefault();
        //    }
        //    catch (Exception e)
        //    {
        //        string i = e.Message;

        //        try
        //        {
        //            sql.SaveData("dbo.spCategory_Insert", dbCategory, "MMFoodData");

        //            dbCategory.Id = sql.LoadData<int, dynamic>("dbo.spCategory_Lookup", new { Name = dbCategory.Name }, "MMFoodData").FirstOrDefault();
        //        }
        //        catch (Exception f)
        //        {
        //            string j = f.Message;
        //            throw new Exception();
        //        }
        //    }   
        //    return dbCategory;
        //}        
        public int Lookup(string name)
        {
            SQLDataAccess sql = new SQLDataAccess();

            return sql.LoadData<int, dynamic>("dbo.spCategory_Lookup", new { Name = name }, "MMFoodData").FirstOrDefault();
        }

        public List<CategoryDBModel> GetAllCategories()
        {
            return new List<CategoryDBModel>();
        }

        public List<CategoryDBModel> SearchByName(string name)
        {
            SQLDataAccess sql = new SQLDataAccess();

            List<CategoryDBModel> output = new List<CategoryDBModel>();


            output = sql.LoadData<CategoryDBModel, dynamic>("dbo.spCategory_SearchByName", new
            {
                Name = name
            }, "MMFoodData");

            return output;
        }
    }
}
