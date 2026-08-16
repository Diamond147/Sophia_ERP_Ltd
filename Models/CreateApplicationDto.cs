namespace Sophia_Ltd.Models
{
    public class CreateApplicationDto
    {
        public required string ApplicantName { get; set; }
        public required string ApplicantEmail { get; set; }
        public required string Position { get; set; }

        public Guid? EmployeeId { get; set; }
        //public Employee? ByEmployee { get; set; }
    }
}
