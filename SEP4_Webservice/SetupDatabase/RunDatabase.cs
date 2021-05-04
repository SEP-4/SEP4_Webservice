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
            create.createDehumidifierTable();
            create.createHumidifierTable();
            create.creatWindowTable();
            create.createLogStateTable();

            procedures.createLastMeasuermentSP();
            procedures.createInsertMeasuermentSP();

            populate.populateClimateSetting();
            populate.populateGym();
        }
    }
}
