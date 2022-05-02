using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMFoodDataManagerLibrary.Internal.DataAccess;
using MMFoodDataManagerLibrary.Models;

namespace MMFoodDataManagerLibrary.DataAccess
{
    public class StepData
    {
        public void Save(StepDBModel step)
        {
            SQLDataAccess sql = new SQLDataAccess();
            sql.SaveData("dbo.spStep_Insert", step, "MMFoodData");
        }
    }
}
