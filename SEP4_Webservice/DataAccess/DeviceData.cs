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
    public class DeviceData
    {
        public void turnOffAC(int gym_id)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                 connection.Query<AC>("dbo.spTurnOff_AC @Gym_ID", new { Gym_ID = gym_id });
            }
        }

        public void turnOnAC(int gym_id)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                 connection.Query<AC>("dbo.spTurnOn_AC @Gym_ID", new { Gym_ID = gym_id });
            }
        }

        public AC GetACByGymID(int gym_id)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                var output = connection.Query<AC>("dbo.spAC_GetByGymID @Gym_ID", new { Gym_ID = gym_id }).First();
                return output;
            }
        }

        public void turnOffDehumidifier(int gym_id)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                connection.Query<Dehumidifier>("dbo.spTurnOff_Dehumidifier @Gym_ID", new { Gym_ID = gym_id });
            }
        }

        public void turnOnDehumidifier(int gym_id)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                connection.Query<Dehumidifier>("dbo.spTurnOn_Dehumidifier @Gym_ID", new { Gym_ID = gym_id });
            }
        }

        public Dehumidifier GetDehumidifierByGymID(int gym_id)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                var output = connection.Query<Dehumidifier>("dbo.spDehumidifier_GetByGymID @Gym_ID", new { Gym_ID = gym_id }).First();
                return output;
            }
        }

        public void turnOffHumidifier(int gym_id)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                connection.Query<Humidifier>("dbo.spTurnOff_Humidifier @Gym_ID", new { Gym_ID = gym_id });
            }
        }

        public void turnOnHumidifier(int gym_id)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                connection.Query<Humidifier>("dbo.spTurnOn_Humidifier @Gym_ID", new { Gym_ID = gym_id });
            }
        }

        public Humidifier GetHumidifierByGymID(int gym_id)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                var output = connection.Query<Humidifier>("dbo.spHumidifier_GetByGymID @Gym_ID", new { Gym_ID = gym_id }).First();
                return output;
            }
        }

        public void turnOffWindow(int gym_id)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                connection.Query<Window>("dbo.spTurnOff_Window @Gym_ID", new { Gym_ID = gym_id });
            }
        }

        public void turnOnWindow(int gym_id)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                connection.Query<Window>("dbo.spTurnOn_Window @Gym_ID", new { Gym_ID = gym_id });
            }
        }

        public Window GetWindowByGymID(int gym_id)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                var output = connection.Query<Window>("dbo.spWindow_GetByGymID @Gym_ID", new { Gym_ID = gym_id }).First();
                return output;
            }
        }
    }
}
