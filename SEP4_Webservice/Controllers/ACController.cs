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
    public class ACController : ControllerBase
    {
        private IDeviceService DeviceService;
        public ACController(IDeviceService deviceService)
        {
            DeviceService = deviceService;
        }

        [HttpGet]
        [Route("turnOff/{Gym_ID:int}")]
        public async Task<ActionResult> TurnOffAC([FromRoute] int Gym_ID)
        {
            try
            {
                await DeviceService.turnOffAC(Gym_ID);
                return Ok("AC is turned off!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("turnOn/{Gym_ID:int}")]
        public async Task<ActionResult> TurnOnAC([FromRoute] int Gym_ID)
        {
            try
            {
                 await DeviceService.turnOnAC(Gym_ID);
                return Ok("AC is turned on!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("{Gym_ID:int}")]
        public async Task<ActionResult<AC>> GetACByGymID([FromRoute] int Gym_ID)
        {
            try
            {
                AC ac = await DeviceService.GetACByGymID(Gym_ID);
                return Ok(ac);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("turnOnAutomation/{Gym_ID:int}")]
        public async Task<ActionResult> TurnOnACAutomation([FromRoute] int Gym_ID)
        {
            try
            {
                await DeviceService.turnOnACAutomation(Gym_ID);
                return Ok("AC automation is turned on!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("turnOffAutomation/{Gym_ID:int}")]
        public async Task<ActionResult> TurnOffACAutomation([FromRoute] int Gym_ID)
        {
            try
            {
                await DeviceService.turnOffACAutomation(Gym_ID);
                return Ok("AC automation is turned off!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}
