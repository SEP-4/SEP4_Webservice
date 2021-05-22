using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP4_Webservice.DataAccess;
using SEP4_Webservice.Model;

namespace SEP4_Webservice.Data
{
    public class DeviceService : IDeviceService
    {
        private DeviceData dataAccess;
        private AC ac;
        private Dehumidifier dehumiditifier;
        private Humidifier humiditifier;
        private Window window;
        public DeviceService(DeviceData dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public async Task turnOffAC(int gym_id)
        {
            dataAccess.turnOffAC(gym_id);
        }

        public async Task turnOnAC(int gym_id)
        {
            dataAccess.turnOnAC(gym_id);
        }

        public async Task<AC> GetACByGymID(int gym_id)
        {
            ac = dataAccess.GetACByGymID(gym_id);
            return ac;
        }

        public async Task turnOffDehumidifier(int gym_id)
        {
            dataAccess.turnOffDehumidifier(gym_id);
        }

        public async Task turnOnDehumidifier(int gym_id)
        {
            dataAccess.turnOnDehumidifier(gym_id);
        }

        public async Task<Dehumidifier> GetDehumidifierByGymID(int gym_id)
        {
            dehumiditifier = dataAccess.GetDehumidifierByGymID(gym_id);
            return dehumiditifier;
        }

        public async Task turnOffHumidifier(int gym_id)
        {
            dataAccess.turnOffHumidifier(gym_id);
        }

        public async Task turnOnHumidifier(int gym_id)
        {
            dataAccess.turnOnHumidifier(gym_id);
        }

        public async Task<Humidifier> GetHumidifierByGymID(int gym_id)
        {
            humiditifier = dataAccess.GetHumidifierByGymID(gym_id);
            return humiditifier;
        }

        public async Task turnOffWindow(int gym_id)
        {
            dataAccess.turnOffWindow(gym_id);
        }

        public async Task turnOnWindow(int gym_id)
        {
            dataAccess.turnOnWindow(gym_id);
        }

        public async Task<Window> GetWindowByGymID(int gym_id)
        {
            window = dataAccess.GetWindowByGymID(gym_id);
            return window;
        }
    }
}
