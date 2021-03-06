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
    public class MeasurementController : ControllerBase
    {
        private IMeasurementService MeasurementService;
        public MeasurementController(IMeasurementService measurementService)
        {
            MeasurementService = measurementService;
        }

        [HttpGet]
        public async Task<ActionResult<MeasurementTime>> GetLastTemperature()
        {
            try
            {
                MeasurementTime measurement = await MeasurementService.GetLastMeasurement();
                return Ok(measurement);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("{Date}")]
        public async Task<ActionResult<MeasurementGraph>> GetLastTemperature([FromRoute] string Date)
        {
            try
            {
                List<MeasurementGraph> measurements = await MeasurementService.GetListOfMeasurementByDate(Date);
                return Ok(measurements);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("post")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Measurement>> AddMeasureMent([FromBody] Measurement measurement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Measurement added = await MeasurementService.AddMeasurement(measurement);
                return Created($"/{added.Measurement_ID}", added); // return newly added to-do, to get the auto generated id
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}
