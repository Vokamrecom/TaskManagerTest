namespace TaskManager.Data
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime? EstimatedCompletionTime { get; set; }
        public TimeSpan? ActualCompletionTime { get; set; }

        public int CreatorId { get; set; }
        public User Creator { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
