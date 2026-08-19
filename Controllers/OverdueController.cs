using Microsoft.AspNetCore.Mvc;
using Sophia_ERP_Ltd.Models;

[ApiController]
[Route("api/[controller]")]
public class OverdueApplicationsController : ControllerBase
{
    [HttpGet("test-overdue")]
    public IActionResult GetOverdueApplications()
    {
        // Hardcoded test data
        var applications = new List<OverdueTestApplication>
        {
            new() { Id = 1, SubmittedAt = new DateOnly(2024, 10, 1), ProcessingDays = 5 },
            new() { Id = 2, SubmittedAt = new DateOnly(2024, 10, 3), ProcessingDays = 2 },
            new() { Id = 3, SubmittedAt = new DateOnly(2024, 10, 5), ProcessingDays = 10 }
        };

        var today = new DateOnly(2024, 10, 10);

        var overdueApplications = applications
            .Select(app => new OverdueApplicationResult
            {
                Id = app.Id,
                ExpectedCompletion = app.SubmittedAt.AddDays(app.ProcessingDays)
            })
            .Where(result => result.ExpectedCompletion < today)
            .ToList();

        return Ok(overdueApplications);
    }
}