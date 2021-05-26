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
        public MeasurementTime GetLastMeasurement()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                var output = connection.Query<Measurement>("dbo.spMeasurement_GetLast").ToList();
                MeasurementTime returnMeasurenent = new MeasurementTime
                {
                    Measurement_ID = output.First().Measurement_ID,
                    Gym_ID = output.First().Gym_ID,
                    Temperature = output.First().Temperature,
                    Humidity = output.First().Humidity,
                    CO2Level = output.First().CO2Level,
                    Date = output.First().Date,
                    Time = output.First().Time.Ticks
                };
                DateTime dateTime = new DateTime(returnMeasurenent.Date.Year, returnMeasurenent.Date.Month, returnMeasurenent.Date.Day,output.First().Time.Hours, output.First().Time.Minutes, output.First().Time.Seconds);
                DateTime otherDateTime = new DateTime(1970,1,1);
                TimeSpan diff = dateTime - otherDateTime;
                returnMeasurenent.Time = (long)diff.TotalMilliseconds - 7200000;
                return returnMeasurenent;
            }
        }

        public List<Measurement> GetListOfMeasurementByDate(DateTime date)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                var output = connection.Query<Measurement>("dbo.spMeasurement_GetListByDate @Date", new { Date = date }).ToList();
                return output;
            }
        }

        public void InsertMeasurement(Measurement measurement)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                Measurement newMeasurement = new Measurement();
                newMeasurement = measurement;

                connection.Execute("dbo.spInsert_Measurement @Date datatime, @Time time(7),@Temperature float, @Humidity float,@CO2Level float,@Gym_ID int", newMeasurement);
            }
        }
    }
}
