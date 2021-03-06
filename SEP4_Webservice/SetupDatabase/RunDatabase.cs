using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP4_Webservice.SetupDatabase
{
    public class RunDatabase
    {
        static void Main(string[] args)
        {
            CreateDatabase create = new CreateDatabase();
            PopulateDatabase populate = new PopulateDatabase();
            ProceduresDatabase procedures = new ProceduresDatabase();

            create.createClimateSettingTable();
            create.createGymTable();
            create.createMeasurementTable();
            create.createACTable();
            create.createHumidifierTable();
            create.creatWindowTable();
            create.createLogStateTable();

            populate.populateClimateSetting();
            populate.populateGym();
            populate.populateAC();
            populate.populateHumiditifier();
            populate.populateWindow();


            procedures.createLastMeasuermentSP();
            procedures.createInsertMeasuermentSP();
            procedures.createGetGymByEmailSP();
            procedures.turnOffACSP();
            procedures.turnOnACSP();
            procedures.getACSP();
            procedures.turnOffHumidifierSP();
            procedures.turnOnHumidifierSP();
            procedures.getHumidifierSP();
            procedures.turnOffWindowSP();
            procedures.turnOnWindowSP();
            procedures.getWindowSP();
            procedures.turnOffACAutomationSP();
            procedures.turnOnACAutomationSP();
            procedures.turnOffWindowAutomationSP();
            procedures.turnOnWindowAutomationSP();
            procedures.turnOffHumidifierAutomationSP();
            procedures.turnOnHumidifierAutomationSP();
            procedures.getListOfMeasuermentByDateSP();
        }
    }
}
