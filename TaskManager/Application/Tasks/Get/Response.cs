namespace TaskManager.Application.Tasks.Get
{
    public class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public TaskDto Task { get; set; }
    }

    public class TaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Enums.TaskStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EstimatedCompletion { get; set; }
        public DateTime? ActualCompletion { get; set; }

        public string CreatedBy { get; set; }
    }
}
