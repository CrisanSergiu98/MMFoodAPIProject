using MMFoodDataManagerLibrary.Internal.DataAccess;
using MMFoodDataManagerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFoodDataManagerLibrary.DataAccess
{
    public class IngredientData
    {
        SQLDataAccess sql;
        public IngredientData()
        {
            sql = new SQLDataAccess();
        }
        //public IngredientDBModel SaveIngredient(IngredientModel ingredient, string userId)
        //{
        //    SQLDataAccess sql = new SQLDataAccess();
        //    IngredientCategoryData ingredientCategoryData = new IngredientCategoryData();

        //    IngredientDBModel toSaveIngredient = new IngredientDBModel();            

        //    toSaveIngredient.Name = ingredient.Name;
        //    toSaveIngredient.Description = ingredient.Description;
        //    toSaveIngredient.PictureUrl = ingredient.PictureUrl;
        //    toSaveIngredient.UserId = userId;
        //    toSaveIngredient.IsPublished = ingredient.IsPublished;

        //    if (toSaveIngredient.IsPublished)
        //    {
        //        try
        //        {
        //            toSaveIngredient = GetById(toSaveIngredient.Id);
        //        }
        //        catch (Exception e)
        //        {
        //            string message = e.Message;
        //        }
        //    }
        //    else
        //    {
        //        try
        //        {
        //            toSaveIngredient.Id = Lookup(toSaveIngredient);
        //        }
        //        catch
        //        {
        //            toSaveIngredient.IsPublished = false;

        //            try
        //            {
        //                toSaveIngredient.Id = Lookup(toSaveIngredient);
        //            }
        //            catch
        //            {
        //                try
        //                {
        //                    sql.SaveData("dbo.spIngredientCategory_Insert", toSaveIngredient, "MMFoodData");
        //                    toSaveIngredient.Id = Lookup(toSaveIngredient);
        //                }
        //                catch (Exception e)
        //                {
        //                    string message = e.Message;
        //                }
        //            }
        //        }
        //    }

        //    //try
        //    //{
        //    //    toSaveIngredient = GetIngredientByName(ingredient.Name);                
        //    //}
        //    //catch
        //    //{
        //    //    toSaveIngredient.IsPublished = false;

        //    //    toSaveIngredient.CategoryId = ingredientCategoryData.SaveCategory(ingredient.Category, userId).Id;

        //    //    sql.SaveData("dbo.spIngredient_Insert", toSaveIngredient, "MMFoodData");

        //    //    toSaveIngredient.Id = Lookup(toSaveIngredient.Name, toSaveIngredient.IsPublished);
        //    //}

        //    return toSaveIngredient;
        //}                
        public int Lookup(string name)
        {   
            return sql.LoadData<int, dynamic>("dbo.spIngredient_Lookup", new{ Name = name }, "MMFoodData").FirstOrDefault();
        }
        public IngredientDBModel GetById(int id)
        {    
            try
            {
                return sql.LoadData<IngredientDBModel, dynamic>("dbo.spIngredient_GetById", new
                {
                    Id = id
                }, "MMFoodData").FirstOrDefault();
            }
            catch
            {
                throw new Exception();
            }
        }
        public List<IngredientDBModel> SearchByName(string name)
        {
            return sql.LoadData<IngredientDBModel, dynamic>("dbo.spIngredient_SearchByName", new
            {
                Name = name
            }, "MMFoodData");
        }
    }
}
