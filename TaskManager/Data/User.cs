using System.ComponentModel.DataAnnotations;

namespace TaskManager.Data
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Name { get; set; }
        public List<Task> Tasks { get; set; } = new List<Task>();
    }
}
