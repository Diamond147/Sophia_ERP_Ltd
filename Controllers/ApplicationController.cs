using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sophia_Ltd.Database;
using Sophia_Ltd.Models;

namespace Sophia_Ltd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ApplicationController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public IActionResult CreateApplication([FromBody] CreateApplicationDto applicationDto)
        {
            var application = new Application
            {
                ApplicantName = applicationDto.ApplicantName,
                ApplicantEmail = applicationDto.ApplicantEmail,
                Status = "Pending",
                Position = applicationDto.Position,
                SubmittedAt = DateOnly.FromDateTime(DateTime.Now),
                EmployeeId = applicationDto.EmployeeId

            };
            _context.Applications.Add(application);
            _context.SaveChanges();

            // Reload with the relationship populated before returning
            _context.Entry(application)
                .Reference(a => a.ByEmployee)
                .Load();

            return Ok(application);
        }


        [HttpGet]
        public IActionResult GetAllApplications([FromQuery] Guid? id, [FromQuery] string? applicantName)
        {
            var result = _context.Applications
                .Include(a => a.ByEmployee)
                .ToList();

            if (!string.IsNullOrEmpty(applicantName))
            {
                result = result.Where(a => a.ApplicantName.Contains(applicantName)).ToList();
            }
            if (id.HasValue)
            {
                result = result.Where(a => a.ApplicationId == id.Value).ToList();
            }

            return Ok(result);
        }


        [HttpPost]
        [Route("{id}")]
        public IActionResult UpdateApplicationStatus(Guid id, [FromBody] UpdateApplicationDto updateDto)
        {
            var application = _context.Applications.FirstOrDefault(a => a.ApplicationId == id);
            if (application == null)
            {
                return NotFound();
            }

            if (application.Status != "Pending" || application.Status == "Approved" || application.Status == "Rejected")
            {
                return BadRequest($"Application status is {application.Status}.");
            }

            application.Status = updateDto.Status;

            _context.Applications.Update(application);
            _context.SaveChanges();

            return Ok(application);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteApplication(Guid id)
        {
            var application = _context.Applications.FirstOrDefault(a => a.ApplicationId == id);
            if (application == null)
            {
                return NotFound();
            }
            _context.Applications.Remove(application);
            _context.SaveChanges();

            return Ok();
        }


        // pending applications + employee details + submission date
        [HttpGet("pending")]
        public IActionResult GetPendingApplicationWithEmployee()
        {
            var pendingApplications = _context.Applications
                .Include(a => a.ByEmployee)
                .Where(a => a.Status == "Pending")
                .ToList();

            return Ok(pendingApplications);
        }

    }
}

