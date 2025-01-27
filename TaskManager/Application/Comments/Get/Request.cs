using MediatR;

namespace TaskManager.Application.Comments.Get
{
    public class Request : IRequest<Response>
    {
        public int TaskId { get; set; }
    }
}