using System.ComponentModel.DataAnnotations;

namespace TaskManager.Data
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }
    }
}
