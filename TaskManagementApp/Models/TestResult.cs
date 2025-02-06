namespace TaskManagementApp.Models
{
    public class TestResult
    {
        public required string Id { get; set; }
        public required string UserId { get; set; }
        public int Input { get; set; }
        public required string Output { get; set; }
    }

    public class CreateTestResultRequest
    {
        public int Input { get; set; }
    }

    public class UpdateTestResultRequest
    {
        public int Input { get; set; }
        public string Output { get; set; } = string.Empty;
    }
}
