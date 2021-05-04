using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace SEP4_Webservice.SetupDatabase
{
    public class CreateDatabase
    {
        public void createClimateSettingTable()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                string code = "IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClimateSetting]') AND type in (N'U')) " +
"CREATE TABLE[dbo].[ClimateSetting](" +
    "[ClimateSetting_ID][int] IDENTITY NOT NULL, " +
    "[MaxTemperature] [float] NULL, " +
    "[MinTemperature] [float] NULL, " +
    "[MaxCO2] [float] NULL, " +
    "[MinCO2] [float] NULL, " +
    "[MaxHumidity] [float] NULL, " +
    "[MinHumidity] [float] NULL, " +
 "CONSTRAINT[PK_ClimateSetting] PRIMARY KEY CLUSTERED" +
"(" +
   "[ClimateSetting_ID] ASC" +
")WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]" +
") ON[PRIMARY]";

                connection.Execute(code);
            }
        }

        public void createGymTable()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                string code = "IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Gym]') AND type in (N'U')) " +
"CREATE TABLE[dbo].[Gym]( " +
    "[Gym_ID][int] IDENTITY NOT NULL, " +
    "[ClimateSetting_ID] [int] NOT NULL, " +
    "[Addres] [nchar](50) NULL, " +
    "[Contact] [nchar](30) NULL, " +
    "[PostCode] [nchar](10) NULL, " +
    "[City] [nchar](30) NULL, " +
    "[Password] [nchar](30) NULL, " +
    "[Email] [nchar](50) NULL, " +
 "CONSTRAINT[PK_Gym] PRIMARY KEY CLUSTERED" +
"(" +
   "[Gym_ID] ASC" +
")WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]" +
") ON[PRIMARY]" +
"ALTER TABLE[dbo].[Gym]  WITH CHECK ADD CONSTRAINT[FK_Gym_Gym] FOREIGN KEY([Gym_ID])" +
"REFERENCES[dbo].[Gym]([Gym_ID])" +
"ALTER TABLE[dbo].[Gym] CHECK CONSTRAINT[FK_Gym_Gym] " +
"ALTER TABLE dbo.Gym ADD CONSTRAINT FK_Gym_0 FOREIGN KEY(ClimateSetting_ID) REFERENCES dbo.ClimateSetting(ClimateSetting_ID); ";

                connection.Execute(code);
            }
        }


        public void createMeasurementTable()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                string code =
"CREATE TABLE [dbo].[Measurement](" +
    "[Measurement_ID][int] IDENTITY NOT NULL," +
    "[Date] [datetime] NULL," +
    "[Time] [time] NULL," +
    "[Temperature] [float] NULL," +
    "[Humidity] [float] NULL," +
    "[CO2Level] [float] NULL," +
    "[Gym_ID] [int] NOT NULL," +
 "CONSTRAINT[PK_Temperature] PRIMARY KEY CLUSTERED" +
"(" +
   "[Measurement_ID] ASC" +
")WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]" +
") ON[PRIMARY]" +
" ALTER TABLE dbo.Measurement ADD CONSTRAINT FK_Measurement_0 FOREIGN KEY(Gym_ID) REFERENCES dbo.Gym(Gym_ID); ";

                connection.Execute(code);
            }
        }

        public void createACTable()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                string code = "IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AC]') AND type in (N'U')) "+
"CREATE TABLE[dbo].[AC](" +
    "[AC_ID][int] IDENTITY NOT NULL, " +
    "[Gym_ID] [int] NOT NULL, " +
    "[State] [bit] NULL, " +
    "[TargetTemperature] [float] NULL, " +
 "CONSTRAINT[PK_AC] PRIMARY KEY CLUSTERED " +
"(" +
    "[AC_ID] ASC " +
")WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY] " +
") ON[PRIMARY] " +
"ALTER TABLE dbo.AC ADD CONSTRAINT FK_AC_0 FOREIGN KEY(Gym_ID) REFERENCES dbo.Gym(Gym_ID); ";

                connection.Execute(code);
            }
        }

        public void createDehumidifierTable()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                string code = "IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Dehumidifier]') AND type in (N'U')) "+
"CREATE TABLE[dbo].[Dehumidifier](" +
    "[Dehumidifier_ID][int] IDENTITY NOT NULL, " +
    "[Gym_ID] [int] NOT NULL, " +
    "[State] [bit] NULL, " +
"CONSTRAINT[PK_Dehumidifier] PRIMARY KEY CLUSTERED " +
"(" +
   "[Dehumidifier_ID] ASC " +
")WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY] " +
") ON[PRIMARY] " +
"ALTER TABLE dbo.Dehumidifier ADD CONSTRAINT FK_Dehumidifier_0 FOREIGN KEY(Gym_ID) REFERENCES dbo.Gym(Gym_ID); ";

                connection.Execute(code);
            }
        }

        public void createHumidifierTable()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                string code = "IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Humidifier]') AND type in (N'U')) "+
"CREATE TABLE[dbo].[Humidifier](" +
    "[Humidifier_ID][int] IDENTITY NOT NULL, " +
    "[Gym_ID] [int] NOT NULL, " +
    "[State] [bit] NULL, " +
 "CONSTRAINT[PK_Humidifier] PRIMARY KEY CLUSTERED " +
"(" +
    "[Humidifier_ID] ASC " +
")WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY] " +
") ON[PRIMARY] " +
"ALTER TABLE dbo.Humidifier ADD CONSTRAINT FK_Humidifier_0 FOREIGN KEY(Gym_ID) REFERENCES dbo.Gym(Gym_ID); ";

                connection.Execute(code);
            }
        }

        public void creatWindowTable()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                string code = "IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Window]') AND type in (N'U')) " +
"CREATE TABLE[dbo].[Window](" +
    "[Window_ID][int] IDENTITY NOT NULL, " +
    "[Gym_ID] [int] NOT NULL, " +
    "[State] [bit] NULL, " +
 "CONSTRAINT[PK_Window] PRIMARY KEY CLUSTERED " +
"(" +
    "[Window_ID] ASC " +
")WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY] " +
") ON[PRIMARY] " +
"ALTER TABLE dbo.Window ADD CONSTRAINT FK_Window_0 FOREIGN KEY(Gym_ID) REFERENCES dbo.Gym(Gym_ID); ";

                connection.Execute(code);
            }
        }

        public void createLogStateTable()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SEP4DB")))
            {
                string code = "IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LogState]') AND type in (N'U')) " +
"CREATE TABLE[dbo].[LogState](" +
    "[LogState_ID][int] IDENTITY NOT NULL, " +
    "[Gym_ID] [int] NOT NULL, " +
    "[Window_ID] [int]  NULL, " +
    "[AC_ID] [int]  NULL, " +
    "[Dehumidifier_ID] [int]  NULL, " +
    "[Humidifier_ID] [int]  NULL, " +
    "[Action] [nchar](100) NULL, " +
    "[Date] [datetime] NULL, " +
    "[Time] [time] NULL, " +
 "CONSTRAINT[PK_LogState] PRIMARY KEY CLUSTERED " +
"(" +
    "[LogState_ID] ASC " +
")WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY] " +
") ON[PRIMARY] " +
"ALTER TABLE dbo.LogState ADD CONSTRAINT FK_LogState_0 FOREIGN KEY(Gym_ID) REFERENCES dbo.Gym(Gym_ID); " +
"ALTER TABLE dbo.LogState ADD CONSTRAINT FK_LogState_1 FOREIGN KEY(Window_ID) REFERENCES dbo.Window(Window_ID); " +
"ALTER TABLE dbo.LogState ADD CONSTRAINT FK_LogState_2 FOREIGN KEY(AC_ID) REFERENCES dbo.AC(AC_ID); " +
"ALTER TABLE dbo.LogState ADD CONSTRAINT FK_LogState_3 FOREIGN KEY(Dehumidifier_ID) REFERENCES dbo.Dehumidifier(Dehumidifier_ID); " +
"ALTER TABLE dbo.LogState ADD CONSTRAINT FK_LogState_4 FOREIGN KEY(Humidifier_ID) REFERENCES dbo.Humidifier(Humidifier_ID); ";

                connection.Execute(code);
            }
        }
    }
}
