using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEP4_Webservice.Data;
using SEP4_Webservice.Model;

namespace SEP4_Webservice.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class HumidifierController : ControllerBase
    {
        private IDeviceService DeviceService;
        public HumidifierController(IDeviceService deviceService)
        {
            DeviceService = deviceService;
        }

        [HttpGet]
        [Route("turnOff/{Gym_ID:int}")]
        public async Task<ActionResult> TurnOffHumidifier([FromRoute] int Gym_ID)
        {
            try
            {
                await DeviceService.turnOffHumidifier(Gym_ID);
                return Ok("Humidifier is turned off!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("turnOn/{Gym_ID:int}")]
        public async Task<ActionResult> TurnOnHumidifier([FromRoute] int Gym_ID)
        {
            try
            {
                await DeviceService.turnOnHumidifier(Gym_ID);
                return Ok("Humidifier is turned on!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("{Gym_ID:int}")]
        public async Task<ActionResult<Humidifier>> GetHumidifierByGymID([FromRoute] int Gym_ID)
        {
            try
            {
                Humidifier humidifier = await DeviceService.GetHumidifierByGymID(Gym_ID);
                return Ok(humidifier);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("turnOnAutomation/{Gym_ID:int}")]
        public async Task<ActionResult> TurnOnHumidifierAutomation([FromRoute] int Gym_ID)
        {
            try
            {
                await DeviceService.turnOnHumidifierAutomation(Gym_ID);
                return Ok("Humidifier automation is turned on!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("turnOffAutomation/{Gym_ID:int}")]
        public async Task<ActionResult> TurnOffHumidifierAutomation([FromRoute] int Gym_ID)
        {
            try
            {
                await DeviceService.turnOffHumidifierAutomation(Gym_ID);
                return Ok("Humidifier automation is turned off!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}
