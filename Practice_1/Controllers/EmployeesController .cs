using Microsoft.AspNetCore.Mvc;
using Practice_1.Models;
using Practice_1.Service.IService;

namespace Practice_1.Controllers
{
    public class EmployeesController : Controller
    {

        private readonly IEmployeeService _service;

        public EmployeesController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _service.GetEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _service.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            var createdEmployee = await _service.AddEmployeeAsync(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.Id }, createdEmployee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            await _service.UpdateEmployeeAsync(id, employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _service.DeleteEmployeeAsync(id);
            return NoContent();
        }

    }
}
