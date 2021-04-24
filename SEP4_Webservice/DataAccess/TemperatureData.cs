using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using SEP4_Webservice.Model;

namespace SEP4_Webservice.DataAccess
{
    public class TemperatureData
    {
        public Temperature GetLastTemperature()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                //var output = connection.Query<Employee>($"select * from Employee where Name='{ name }'").ToList();
                var output = connection.Query<Temperature>("dbo.spTemperature_GetLast").ToList();
                return output.First();
            }
        }
    }
}
