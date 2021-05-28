using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP4_Webservice.Model;

namespace SEP4_Webservice.Data
{
    public interface IDeviceService
    {
        Task turnOffAC(int gym_id);
        Task turnOnAC(int gym_id);
        Task<AC> GetACByGymID(int gym_id);


        Task turnOffHumidifier(int gym_id);
        Task turnOnHumidifier(int gym_id);
        Task<Humidifier> GetHumidifierByGymID(int gym_id);

        Task turnOffWindow(int gym_id);
        Task turnOnWindow(int gym_id);
        Task<Window> GetWindowByGymID(int gym_id);

        Task turnOffACAutomation(int gym_id);
        Task turnOnACAutomation(int gym_id);
        Task turnOffHumidifierAutomation(int gym_id);
        Task turnOnHumidifierAutomation(int gym_id);
        Task turnOffWindowAutomation(int gym_id);
        Task turnOnWindowAutomation(int gym_id);
    }
}

