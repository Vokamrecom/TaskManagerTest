using System.ComponentModel.DataAnnotations;

namespace TaskManager.Data
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Enums.TaskStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EstimatedCompletion { get; set; }
        public DateTime? ActualCompletion { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
