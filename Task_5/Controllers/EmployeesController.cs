using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_5.Services.Employee;

namespace Task_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeServices _employeeServices;



        public EmployeesController(IEmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }

        [HttpGet("{empId}")]
        public async Task<ActionResult<Tables.Employee>> GetEmployeeByIdAsync(int empId)
        {
            var employee = await _employeeServices.GetEmployeeByIdAsync(empId);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpGet]
        public async Task<ActionResult<List<Tables.Employee>>> GetAllEmployeesAsync()
        {
            var employees = await _employeeServices.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpPost]
        public async Task<ActionResult<Tables.Employee>> AddEmployeeAsync(Tables.Employee employee)
        {
            var addedEmployee = await _employeeServices.AddEmployeeAsync(employee);
            return CreatedAtAction(nameof(GetEmployeeByIdAsync), new { empId = addedEmployee.empId }, addedEmployee);
        }

        [HttpPut("{empId}")]
        public async Task<IActionResult> UpdateEmployeeAsync(int empId, Tables.Employee updatedEmployee)
        {
            await _employeeServices.UpdateEmployeeAsync(empId, updatedEmployee);
            return NoContent();
        }

        [HttpDelete("{empId}")]
        public async Task<IActionResult> DeleteEmployeeAsync(int empId)
        {
            await _employeeServices.DeleteEmployeeAsync(empId);
            return NoContent();
        }

        [HttpGet("SendMessage")]
        public IActionResult SendMessage(string email)
        {
            RecurringJob.AddOrUpdate(() => _employeeServices.SendMessage(email), Cron.Monthly);
            return Ok();
        }
    }
}
