using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEP4_Webservice.Data.TemperatureService;
using SEP4_Webservice.Model;

namespace SEP4_Webservice.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class TemperatureController : ControllerBase
    {
        private ITemperatureService TemperatureService;
        public TemperatureController(ITemperatureService temperatureService)
        {
            TemperatureService = temperatureService;
        }

        [HttpGet]
        public async Task<ActionResult<Temperature>> GetLastTemperature()
        {
            try
            {
                Temperature temperature = await TemperatureService.GetLastTemperature();
                return Ok(temperature);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}
