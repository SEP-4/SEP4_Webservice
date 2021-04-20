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
    public class EmployeesController : ControllerBase
    {
        private IEmployeeService EmployeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            EmployeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Employee>>> GetEmployeesByName([FromQuery] string name)
        {
            try
            {
                IList<Employee> adults = await EmployeeService.GetEmployeesByName(name);
                return Ok(adults);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Employee>> AddEmployee([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Employee added = await EmployeeService.AddEmployee(employee);
                return Created($"/{added.Employee_ID}", added); // return newly added to-do, to get the auto generated id
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }


    }
}
