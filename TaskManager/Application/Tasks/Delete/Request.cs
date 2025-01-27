using MediatR;

namespace TaskManager.Application.Tasks.Delete
{
    public class Request : IRequest<Response>
    {
        public int TaskId { get; set; }
    }
}
