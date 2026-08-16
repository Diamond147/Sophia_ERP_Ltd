namespace Sophia_Ltd.Models
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Status { get; set; } = "Pending";
        public required decimal Salary { get; set; }
        public DateOnly CreatedAt { get; set; } 
        public DateOnly? UpdateAt { get; set; }

        public ICollection<Application> ReviewedApplications { get; set; } = new List<Application>();
    }
}
