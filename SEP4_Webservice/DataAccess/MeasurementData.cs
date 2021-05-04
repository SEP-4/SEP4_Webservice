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

        public void InsertMeasurement(Measurement measurement)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                Measurement newMeasurement = new Measurement();
                newMeasurement = measurement;

                connection.Execute("dbo.spInsert_Measurement @Date date, @Time time(7),@Temperature float, @Humidity float,@CO2Level float,@Gym_ID int", newMeasurement);
            }
        }
    }
}
