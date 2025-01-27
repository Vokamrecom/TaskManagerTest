using MediatR;

namespace TaskManager.Application.Tasks.GetAll
{
    public class Request : IRequest<Response>
    {
        public Enums.TaskStatus Status { get; set; }
        public int? UserId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
