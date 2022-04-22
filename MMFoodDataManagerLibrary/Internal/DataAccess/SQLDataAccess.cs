using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFoodDataManagerLibrary.Internal.DataAccess
{
    /// <summary>
    /// Internal class to handle the data base "talking".
    /// We made it internal because we wint call it directly from our UI
    /// </summary>
    internal class SQLDataAccess
    {
        /// <summary>
        /// Get the conenction string from the App.Config/Web.Config depending on the app that we are using
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetConnectionString(string name) 
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        /// <summary>
        /// The main method we are going to use to load data from our db.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="storedProcedures"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionStringName"></param>
        /// <returns></returns>
        public List<T> LoadData<T, U>(string storedProcedures, U parameters, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            using(IDbConnection connection = new SqlConnection(connectionString))
            {
                List<T> rows = connection.Query<T>(storedProcedures, parameters, 
                    commandType: CommandType.StoredProcedure).ToList();

                return rows;
            }
        }

        /// <summary>
        /// The main method we are going to use to save our data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storedProcedures"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionStringName"></param>
        public void SaveData<T>(string storedProcedures, T parameters, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(storedProcedures, parameters, commandType: CommandType.StoredProcedure);                
            }
        }
    }
}
