namespace TaskManagementApp.Models
{
    public class TestResult
    {
        public required string Id { get; set; }
        public required string UserId { get; set; }
        public int Input { get; set; }
        public int Output { get; set; }
    }

}
