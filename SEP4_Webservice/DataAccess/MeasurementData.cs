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
    public class MeasurementData
    {
        public Measurement GetLastMeasurement()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                var output = connection.Query<Measurement>("dbo.spMeasurement_GetLast").ToList();
                return output.First();
            }
        }
    }
}
