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
    public class DeviceController : ControllerBase
    {
        private IDeviceService DeviceService;
        public DeviceController(IDeviceService deviceService)
        {
            DeviceService = deviceService;
        }

        [HttpPatch]
        [Route("turnOffAC/{Gym_ID:int}")]
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

        [HttpPatch]
        [Route("turnOnAC/{Gym_ID:int}")]
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
        [Route("AC/{Gym_ID:int}")]
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

        [HttpPatch]
        [Route("turnOffDehumidifier/{Gym_ID:int}")]
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

        [HttpPatch]
        [Route("turnOnDehumidifier/{Gym_ID:int}")]
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
        [Route("Dehumidifier/{Gym_ID:int}")]
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

        [HttpPatch]
        [Route("turnOffHumidifier/{Gym_ID:int}")]
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

        [HttpPatch]
        [Route("turnOnHumidifier/{Gym_ID:int}")]
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
        [Route("Humidifier/{Gym_ID:int}")]
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

        [HttpPatch]
        [Route("turnOffWindow/{Gym_ID:int}")]
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

        [HttpPatch]
        [Route("turnOnWindow/{Gym_ID:int}")]
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
        [Route("Window/{Gym_ID:int}")]
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
