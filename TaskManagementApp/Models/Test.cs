namespace TaskManagementApp.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        // Внешний ключ
        public int AuthorId { get; set; }
        public User Author { get; set; }
    }

}
