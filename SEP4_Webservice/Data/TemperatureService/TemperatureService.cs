using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP4_Webservice.DataAccess;
using SEP4_Webservice.Model;

namespace SEP4_Webservice.Data.TemperatureService
{
    public class TemperatureService : ITemperatureService
    {
        private TemperatureData dataAccess;

        public TemperatureService(TemperatureData dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public async Task<Temperature> GetLastTemperature()
        {
            Temperature temperature = new Temperature();
            temperature = dataAccess.GetLastTemperature();
            return temperature;
        }
    }
}
