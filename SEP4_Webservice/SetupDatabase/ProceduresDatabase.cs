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
                string code = "create procedure dbo.spInsert_Measurement " +
            "@Date datetime, " +
            "@Time time, " +
            "@Temperature float, " +
            "@Humidity float, " +
            "@CO2Level float, " +
            "@Gym_ID int " +
           " as " +
            "begin " +
            "SET NOCOUNT ON; " +
           " INSERT INTO SEP4DB.dbo.Measurement(Date, Time, Temperature, Humidity, CO2Level, Gym_ID) " +
            "VALUES(@Date, @Time, @Temperature, @Humidity, @CO2Level, @Gym_ID); " +
                "end";

                connection.Execute(code);
            }
        }

        public void getListOfMeasuermentByDateSP()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                string code = "create procedure dbo.spMeasurement_GetListByDate " +
             "@Date nvarchar(50) " +
             "as " +
             "begin " +
             "SET NOCOUNT ON; " +
             "SELECT Measurement_ID, Date, Time, Gym_ID, Temperature, Humidity, CO2Level FROM dbo.Measurement " +
             "where date = @Date " +
             "end";

                connection.Execute(code);
            }
        }

        public void createGetGymByEmailSP()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                string code = "create procedure dbo.spGym_GetByEmail " +
                   "@Email nvarchar(50) " +
                "as " +
                "begin " +
                   "SET NOCOUNT ON; " +
                   "select Gym_ID, Address, Contact, PostCode, City, Email, Password " +
                   "from dbo.Gym " +
                   "where Email = @Email " +
                "end";

                connection.Execute(code);
            }
        }

        public void turnOffACSP()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                string code = "create procedure dbo.spTurnOff_AC " +
                "@Gym_ID int " +
            "as " +
            "begin " +
                 "SET NOCOUNT ON; " +
                    "UPDATE SEP4DB.dbo.AC SET State = 0 " +
                    "where Gym_ID = @Gym_ID; " +
            "end";

                connection.Execute(code);
            }
        }

        public void turnOnACSP()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                string code = "create procedure dbo.spTurnOn_AC " +
                "@Gym_ID int " +
            "as " +
            "begin " +
                 "SET NOCOUNT ON; " +
                    "UPDATE SEP4DB.dbo.AC SET State = 1 " +
                    "where Gym_ID = @Gym_ID; " +
            "end";

                connection.Execute(code);
            }
        }

        public void getACSP()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                string code = "create procedure dbo.spAC_GetByGymID " +
                   " @Gym_ID int " +
                "as " +
                "begin " +
                    "SET NOCOUNT ON; " +
                    "select Gym_ID, State, TargetTemperature, automation  " +
                    "from dbo.AC " +
                    "where Gym_ID = @Gym_ID " +
                "end";

                connection.Execute(code);
            }
        }


        public void turnOffHumidifierSP()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                string code = "create procedure dbo.spTurnOff_Humidifier " +
                "@Gym_ID int " +
            "as " +
            "begin " +
                 "SET NOCOUNT ON; " +
                    "UPDATE SEP4DB.dbo.Humidifier SET State = 0 " +
                    "where Gym_ID = @Gym_ID; " +
            "end";

                connection.Execute(code);
            }
        }

        public void turnOnHumidifierSP()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                string code = "create procedure dbo.spTurnOn_Humidifier " +
                "@Gym_ID int " +
            "as " +
            "begin " +
                 "SET NOCOUNT ON; " +
                    "UPDATE SEP4DB.dbo.Humidifier SET State = 1 " +
                    "where Gym_ID = @Gym_ID; " +
            "end";

                connection.Execute(code);
            }
        }

        public void getHumidifierSP()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                string code = "create procedure dbo.spHumidifier_GetByGymID " +
                   " @Gym_ID int " +
                "as " +
                "begin " +
                    "SET NOCOUNT ON; " +
                    "select Gym_ID, State, automation, TargetHumidity  " +
                    "from dbo.Humidifier " +
                    "where Gym_ID = @Gym_ID " +
                "end";

                connection.Execute(code);
            }
        }

        public void turnOffWindowSP()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                string code = "create procedure dbo.spTurnOff_Window " +
                "@Gym_ID int " +
            "as " +
            "begin " +
                 "SET NOCOUNT ON; " +
                    "UPDATE SEP4DB.dbo.Window SET State = 0 " +
                    "where Gym_ID = @Gym_ID; " +
            "end";

                connection.Execute(code);
            }
        }

        public void turnOnWindowSP()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                string code = "create procedure dbo.spTurnOn_Window " +
                "@Gym_ID int " +
            "as " +
            "begin " +
                 "SET NOCOUNT ON; " +
                    "UPDATE SEP4DB.dbo.Window SET State = 1 " +
                    "where Gym_ID = @Gym_ID; " +
            "end";

                connection.Execute(code);
            }
        }

        public void getWindowSP()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                string code = "create procedure dbo.spWindow_GetByGymID " +
                   " @Gym_ID int " +
                "as " +
                "begin " +
                    "SET NOCOUNT ON; " +
                    "select Gym_ID, State, automation, TargetCO2Level " +
                    "from dbo.Window " +
                    "where Gym_ID = @Gym_ID " +
                "end";

                connection.Execute(code);
            }
        }

        public void turnOffWindowAutomationSP()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                string code = "create procedure dbo.spTurnOffAutomation_Window " +
                "@Gym_ID int " +
            "as " +
            "begin " +
                 "SET NOCOUNT ON; " +
                    "UPDATE SEP4DB.dbo.Window SET automation = 0 " +
                    "where Gym_ID = @Gym_ID; " +
            "end";

                connection.Execute(code);
            }
        }

        public void turnOnWindowAutomationSP()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                string code = "create procedure dbo.spTurnOnAutomation_Window " +
                "@Gym_ID int " +
            "as " +
            "begin " +
                 "SET NOCOUNT ON; " +
                    "UPDATE SEP4DB.dbo.Window SET automation = 1 " +
                    "where Gym_ID = @Gym_ID; " +
            "end";

                connection.Execute(code);
            }
        }

        public void turnOffACAutomationSP()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                string code = "create procedure dbo.spTurnOffAutomation_AC " +
                "@Gym_ID int " +
            "as " +
            "begin " +
                 "SET NOCOUNT ON; " +
                    "UPDATE SEP4DB.dbo.AC SET automation = 0 " +
                    "where Gym_ID = @Gym_ID; " +
            "end";

                connection.Execute(code);
            }
        }

        public void turnOnACAutomationSP()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                string code = "create procedure dbo.spTurnOnAutomation_AC " +
                "@Gym_ID int " +
            "as " +
            "begin " +
                 "SET NOCOUNT ON; " +
                    "UPDATE SEP4DB.dbo.AC SET automation = 1 " +
                    "where Gym_ID = @Gym_ID; " +
            "end";

                connection.Execute(code);
            }
        }

        public void turnOffHumidifierAutomationSP()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                string code = "create procedure dbo.spTurnOffAutomation_Humidifier " +
                "@Gym_ID int " +
            "as " +
            "begin " +
                 "SET NOCOUNT ON; " +
                    "UPDATE SEP4DB.dbo.Humidifier SET automation = 0 " +
                    "where Gym_ID = @Gym_ID; " +
            "end";

                connection.Execute(code);
            }
        }

        public void turnOnHumidifierAutomationSP()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                string code = "create procedure dbo.spTurnOnAutomation_Humidifier " +
                "@Gym_ID int " +
            "as " +
            "begin " +
                 "SET NOCOUNT ON; " +
                    "UPDATE SEP4DB.dbo.Humidifier SET automation = 1 " +
                    "where Gym_ID = @Gym_ID; " +
            "end";

                connection.Execute(code);
            }
        }
    }
}
