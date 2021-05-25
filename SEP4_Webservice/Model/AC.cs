using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SEP4_Webservice.Model
{
    public class AC
    {
        public int Gym_ID { get; set; }
        public int State { get; set; }
        public int automation { get; set; }
        public float TargetTemperature { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
