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
    public class DehumidifierController : ControllerBase
    {
        private IDeviceService DeviceService;
        public DehumidifierController(IDeviceService deviceService)
        {
            DeviceService = deviceService;
        }

        [HttpGet]
        [Route("turnOff/{Gym_ID:int}")]
        public async Task<ActionResult> TurnOffDehumidifier([FromRoute] int Gym_ID)
        {
            try
            {
                await DeviceService.turnOffDehumidifier(Gym_ID);
                return Ok("Dehumidifier is turned off!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("turnOn/{Gym_ID:int}")]
        public async Task<ActionResult> TurnOnDehumidifier([FromRoute] int Gym_ID)
        {
            try
            {
                await DeviceService.turnOnDehumidifier(Gym_ID);
                return Ok("Dehumidifier is turned on!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("{Gym_ID:int}")]
        public async Task<ActionResult<Dehumidifier>> GetDehumidifierByGymID([FromRoute] int Gym_ID)
        {
            try
            {
                Dehumidifier dehumidifier = await DeviceService.GetDehumidifierByGymID(Gym_ID);
                return Ok(dehumidifier);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}
