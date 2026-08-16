using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sophia_Ltd.Database;
using Sophia_Ltd.Models;

namespace Sophia_Ltd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public IActionResult CreateEmployee([FromBody] CreateEmployeeDto employeeDto)
        {
            var employee = new Employee
            {
                Name = employeeDto.Name,
                Email = employeeDto.Email,
                Status = "Pending",
                Salary = employeeDto.Salary,
                CreatedAt = DateOnly.FromDateTime(DateTime.Now),

                //UpdateAt = DateOnly.FromDateTime(DateTime.Now),
            };
            _context.Employees.Add(employee);
            _context.SaveChanges();

            return Ok(employee);
        }

        [HttpGet]
        public IActionResult GetAllEmployee([FromQuery] Guid? id, [FromQuery] string? name)
        {
            var result = _context.Employees
                .Include(e => e.ReviewedApplications)
                .ToList();

            if (!string.IsNullOrEmpty(name))
            {
                result = result.Where(e => e.Name.Contains(name)).ToList();
            }

            if (id.HasValue)
            {
                result = result.Where(e => e.EmployeeId == id.Value).ToList();
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("{id}")]
        public IActionResult UpdateEmployeeStatus(Guid id, [FromBody] UpdateEmployeeDto updateDto)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            if (employee.Status != "Pending" || employee.Status == "Approved" || employee.Status == "Rejected")
            {
                return BadRequest($"Employee status is {employee.Status}.");
            }

            employee.Status = updateDto.Status;

            _context.Employees.Update(employee);
            _context.SaveChanges();

            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }
            _context.Employees.Remove(employee);
            _context.SaveChanges();

            return Ok();
        }
    }
}
