using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SEP4_Webservice.Model
{
    public class MeasurementGraph
    {
        public MeasurementGraph(int Hour, string AverageTemperature, string AverageHumidity, string AverageCO2Level)
        {
            this.Hour = Hour;
            this.AverageCO2Level = AverageCO2Level;
            this.AverageHumidity = AverageHumidity;
            this.AverageTemperature = AverageTemperature;
        }


        public int Hour { get; set; }
        public string AverageTemperature { get; set; }
        public string AverageHumidity { get; set; }
        public string AverageCO2Level { get; set; }
        

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
