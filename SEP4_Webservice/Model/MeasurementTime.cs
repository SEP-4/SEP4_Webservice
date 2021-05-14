using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SEP4_Webservice.Model
{
    public class MeasurementTime
    {
        public int Measurement_ID { get; set; }
        public int Gym_ID { get; set; }
        public float Temperature { get; set; }
        public float Humidity { get; set; }
        public float CO2Level { get; set; }
        public DateTime Date { get; set; }
        public long Time { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
