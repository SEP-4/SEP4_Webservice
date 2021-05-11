﻿using System;
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

        public async Task<Measurement> AddMeasurement(Measurement measurement)
        {
            dataAccess.InsertMeasurement(measurement);
            return measurement;
        }

        public async Task<MeasurementTime> GetLastMeasurement()
        {
            MeasurementTime measurement = new MeasurementTime();
            measurement = dataAccess.GetLastMeasurement();
            return measurement;
        }
    }
}
