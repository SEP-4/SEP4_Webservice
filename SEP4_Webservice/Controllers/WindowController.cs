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
    public class WindowController : ControllerBase
    {
        private IDeviceService DeviceService;
        public WindowController(IDeviceService deviceService)
        {
            DeviceService = deviceService;
        }

        [HttpGet]
        [Route("turnOff/{Gym_ID:int}")]
        public async Task<ActionResult> TurnOffWindow([FromRoute] int Gym_ID)
        {
            try
            {
                await DeviceService.turnOffWindow(Gym_ID);
                return Ok("Window is turned off!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("turnOn/{Gym_ID:int}")]
        public async Task<ActionResult> TurnOnWindow([FromRoute] int Gym_ID)
        {
            try
            {
                await DeviceService.turnOnWindow(Gym_ID);
                return Ok("Window is turned on!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("{Gym_ID:int}")]
        public async Task<ActionResult<Window>> GetWindowByGymID([FromRoute] int Gym_ID)
        {
            try
            {
                Window window = await DeviceService.GetWindowByGymID(Gym_ID);
                return Ok(window);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}
