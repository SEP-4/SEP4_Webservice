using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SEP4_Webservice.Model
{
    public class Window
    {
        public int Gym_ID { get; set; }
        public int State { get; set; }
        public int automation { get; set; }
        public float TargetCO2Level { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
