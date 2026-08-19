namespace Sophia_ERP_Ltd.Models
{
    public class OverdueTestApplication
    {
        public int Id { get; set; }
        public DateOnly SubmittedAt { get; set; }
        public int ProcessingDays { get; set; }
    }

    public class OverdueApplicationResult
    {
        public int Id { get; set; }
        public DateOnly ExpectedCompletion { get; set; }
    }
}
