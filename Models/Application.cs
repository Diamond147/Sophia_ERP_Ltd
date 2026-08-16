namespace Sophia_Ltd.Models
{
    public class Application
    {
        public Guid ApplicationId { get; set; }
        public required string ApplicantName { get; set; }
        public required string ApplicantEmail { get; set; }
        public string Status { get; set; } = "Pending";
        public required string Position { get; set; }
        public DateOnly SubmittedAt { get; set; }
        public DateOnly UpdateAt { get; set; }

        public Guid? EmployeeId { get; set; }
        public Employee? ByEmployee { get; set; }
    }
}
