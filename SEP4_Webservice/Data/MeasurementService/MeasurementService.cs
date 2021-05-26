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

        public async Task<List<MeasurementGraph>> GetListOfMeasurementByDate(string date)
        {
            List<Measurement> measurements = new List<Measurement>();
            List<MeasurementGraph> measurementGraphs = new List<MeasurementGraph>();
            DateTime passDate = DateTime.Parse(date);
            measurements = dataAccess.GetListOfMeasurementByDate(passDate);

            int hour = 0;
            int count = 0;
            float avgTemp = 0;
            float avgHum = 0;
            float avgCO2 = 0;

            while (hour < 24)
            {
                count = 0;
                avgTemp = 0;
                avgHum = 0;
                avgCO2 = 0;
                foreach (var mes in measurements)
                {
                    if (mes.Time.Hours == hour)
                    {
                        avgTemp += mes.Temperature;
                        avgHum += mes.Humidity;
                        avgCO2 += mes.CO2Level;
                        count++;
                    }
                }
                avgTemp /= count;
                avgHum /= count;
                avgCO2 /= count;
                MeasurementGraph measurementGraph = new MeasurementGraph(hour, avgTemp.ToString("0.00"), avgHum.ToString("0.00"), avgCO2.ToString("0.00"));
                measurementGraphs.Add(measurementGraph);
                hour++;
            }
            return measurementGraphs;
        }
    }
}
