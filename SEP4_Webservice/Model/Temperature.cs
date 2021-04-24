using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SEP4_Webservice.Model
{
    public class Temperature
    {
        public int Temperature_ID { get; set; }
        public int Gym_ID { get; set; }
        [JsonPropertyName("Temperature")]
        public float temperature { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        
    }
}
