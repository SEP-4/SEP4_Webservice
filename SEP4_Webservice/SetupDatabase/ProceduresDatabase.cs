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
    }
}
