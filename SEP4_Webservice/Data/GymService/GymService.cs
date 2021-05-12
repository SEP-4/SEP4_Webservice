using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP4_Webservice.DataAccess;
using SEP4_Webservice.Model;

namespace SEP4_Webservice.Data
{
    public class GymService : IGymService
    {
        private GymData dataAccess;

        private Gym gym = new Gym();

        public GymService(GymData dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public async Task<Gym> GetGymByEmail(string email)
        {
            gym = dataAccess.GetGymByEmail(email);
            return gym;
        }
    }
}
