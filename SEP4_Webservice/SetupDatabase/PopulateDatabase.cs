using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace SEP4_Webservice.SetupDatabase
{
    public class PopulateDatabase
    {
        public void populateClimateSetting()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                string code = "insert into SEP4DB.dbo.ClimateSetting (MaxTemperature, MinTemperature, MaxCO2, MinCO2, MaxHumidity, MinHumidity) " +
"VALUES(40, 20, 320, 175, 80, 45)";

                connection.Execute(code);
            }
        }

        public void populateGym()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                string code = "insert into SEP4DB.dbo.Gym(ClimateSetting_ID, Address, Contact, PostCode, City,Email,Password) " +
"VALUES(1, 'Vejlevej', 73896443, 8700, 'Horsens', 'gym@gym.com', 'gym123')";

                connection.Execute(code);
            }
        }

        public void populateAC()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                string code = "INSERT INTO Ac (Gym_ID,State,TargetTemperature) VALUES (1,0,22)";

                connection.Execute(code);
            }
        }

        public void populateHumiditifier()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                string code = "INSERT INTO Humidifier(Gym_ID,State) VALUES (1,0)";

                connection.Execute(code);
            }
        }

        public void populateWindow()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                string code = "INSERT INTO Window(Gym_ID,State) VALUES (1,0)";

                connection.Execute(code);
            }
        }
    }
}

