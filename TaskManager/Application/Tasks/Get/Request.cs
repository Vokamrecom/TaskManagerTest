using MediatR;

namespace TaskManager.Application.Tasks.Get
{
    public class Request : IRequest<Response>
    {
        public int TaskId { get; set; }
    }
}
