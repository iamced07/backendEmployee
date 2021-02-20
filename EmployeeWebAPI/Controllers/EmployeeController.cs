using core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServices employeeService;

        public EmployeeController(IEmployeeServices emp)
        {
            employeeService = emp;
        }

        [HttpGet]
        [Route("getEmpList")]
        public async Task<IActionResult> getEmployeeList([FromQuery] string name)
        {
            return Ok(await employeeService.getEmployeeList(name));
        }

        [HttpPost]
        [Route("deleteEmployee")]

        public async Task<IActionResult> deleteEmployee([FromQuery] int employeeId)
        {
            return Ok(await employeeService.deleteEmployee(employeeId));
        }
    }
}
