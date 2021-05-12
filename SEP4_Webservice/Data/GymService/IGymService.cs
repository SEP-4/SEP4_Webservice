using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP4_Webservice.Model;

namespace SEP4_Webservice.Data
{
    public interface IGymService
    {
        Task<Gym> GetGymByEmail(string email);
    }
}
