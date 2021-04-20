using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP4_Webservice.Model
{
    public class Employee
    { 
        public int Employee_ID { get; set; }
        public int Gym_ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
