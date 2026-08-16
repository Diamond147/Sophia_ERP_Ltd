namespace Sophia_Ltd.Models
{
    public class CreateEmployeeDto
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        //public required string Status { get; set; }
        public required decimal Salary { get; set; }
    }
}
