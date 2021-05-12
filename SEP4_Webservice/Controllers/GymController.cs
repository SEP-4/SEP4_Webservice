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
    public class GymController : ControllerBase
    {
        private IGymService GymService;
        public GymController(IGymService gymService)
        {
            GymService = gymService;
        }

        [HttpGet]
        public async Task<ActionResult<Gym>> GetGymByEmail([FromQuery] string email)
        {
            try
            {
                Gym gym = await GymService.GetGymByEmail(email);
                return Ok(gym);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

    }
}
