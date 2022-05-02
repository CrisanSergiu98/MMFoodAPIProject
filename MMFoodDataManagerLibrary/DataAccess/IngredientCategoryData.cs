using MMFoodDataManagerLibrary.Internal.DataAccess;
using MMFoodDataManagerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFoodDataManagerLibrary.DataAccess
{
    public class IngredientCategoryData
    {
        //public IngredientCategoryDBModel SaveCategory(IngredientCategoryDBModel category, string userId)
        //{
        //    //We are going to add DI later don't cringe
        //    //We are going to separate the concerns a bit better
        //    SQLDataAccess sql = new SQLDataAccess();

        //    IngredientCategoryDBModel toSaveCategory = new IngredientCategoryDBModel();

        //    toSaveCategory.Name = category.Name;
        //    toSaveCategory.Description = category.Description;
        //    toSaveCategory.PictureUrl = category.PictureUrl;
        //    toSaveCategory.UserId = userId;
        //    toSaveCategory.IsPublished = category.IsPublished;

        //    if (toSaveCategory.IsPublished)
        //    {
        //        try
        //        {
        //            toSaveCategory = GetById(toSaveCategory.Id);
        //        }
        //        catch(Exception e)
        //        {
        //            string message = e.Message;
        //        }                 
        //    }
        //    else
        //    {
        //        try
        //        {
        //            toSaveCategory.Id = Lookup(toSaveCategory);
        //        }
        //        catch
        //        {
        //            toSaveCategory.IsPublished = false;

        //            try
        //            {
        //                toSaveCategory.Id = Lookup(toSaveCategory);
        //            }
        //            catch
        //            {
        //                try
        //                {
        //                    sql.SaveData("dbo.spIngredientCategory_Insert", toSaveCategory, "MMFoodData");
        //                    toSaveCategory.Id = Lookup(toSaveCategory);
        //                }
        //                catch(Exception e)
        //                {
        //                    string message = e.Message;
        //                }
        //            }
        //        }
        //    }            

        //    return toSaveCategory;
        //}
        public int Lookup(IngredientCategoryDBModel category)
        {
            SQLDataAccess sql = new SQLDataAccess();
            
            return sql.LoadData<int, dynamic>("dbo.spIngredientCategory_Lookup", new { Name = category.Name }, "MMFoodData").FirstOrDefault();                        
        }        
        public IngredientCategoryDBModel GetById(int id)
        {
            SQLDataAccess sql = new SQLDataAccess();

            return sql.LoadData<IngredientCategoryDBModel, dynamic>("dbo.spIngredientCategory_GetById", new
            {
                Id = id
            }, "MMFoodData").FirstOrDefault();
        }
    }
}
