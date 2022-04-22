using MMFoodDataManagerLibrary.Internal.DataAccess;
using MMFoodDataManagerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFoodDataManagerLibrary.DataAccess
{
    public class UserData
    {
        /// <summary>
        /// Method that return an pbject with preperties matching with dbo.user's collumns
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<UserModel> GetUserById(string Id)
        {
            SQLDataAccess sql = new SQLDataAccess();

            var p = new { Id = Id };

            //call the DataAccess method that loads data, pas in p as our "piaring" object and use the MMFoodData as our conncetion
            var output = sql.LoadData<UserModel, dynamic>("dbo.spUserLookup", p, "MMFoodData");

            return output;
        }
    }
}
