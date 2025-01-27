using MediatR;

namespace TaskManager.Application.Tasks.Update
{
    public class Request : IRequest<Response>
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public Enums.TaskStatus Status { get; set; }
        public DateTime? ActualCompletion { get; set; }
        public string Description { get; set; }
    }
}
