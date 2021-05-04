using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace SEP4_Webservice.SetupDatabase
{
    public class ProceduresDatabase
    {
        public void createLastMeasuermentSP()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                string code = "create procedure dbo.spMeasurement_GetLast " +
                "as " +
                "begin " +
                "SET NOCOUNT ON; " +
                "SELECT TOP 1 * " +
                "FROM SEP4DB.dbo.Measurement " +
                "ORDER BY Measurement_ID DESC; " +
                "end";

                connection.Execute(code);
            }
        }

        public void createInsertMeasuermentSP()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                string code = "create procedure dbo.spInsert_Measurement "+
            "@Date datetime, "+
            "@Time time, "+
	        "@Temperature float, "+
            "@Humidity float, "+
            "@CO2Level float, "+
            "@Gym_ID int "+
           " as "+
            "begin "+
            "SET NOCOUNT ON; "+
           " INSERT INTO SEP4DB.dbo.Measurement(Date, Time, Temperature, Humidity, CO2Level, Gym_ID) "+
            "VALUES(@Date, @Time, @Temperature, @Humidity, @CO2Level, @Gym_ID); "+
                "end";

                connection.Execute(code);
            }
        }
    }
}
