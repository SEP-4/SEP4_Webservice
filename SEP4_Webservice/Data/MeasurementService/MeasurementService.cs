using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP4_Webservice.DataAccess;
using SEP4_Webservice.Model;

namespace SEP4_Webservice.Data
{
    public class MeasurementService : IMeasurementService
    {
        private MeasurementData dataAccess;

        public MeasurementService(MeasurementData dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public async Task<Measurement> GetLastMeasurement()
        {
            Measurement temperature = new Measurement();
            temperature = dataAccess.GetLastMeasurement();
            return temperature;
        }
    }
}
