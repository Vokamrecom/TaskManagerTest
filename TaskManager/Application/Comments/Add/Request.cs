using MediatR;

namespace TaskManager.Application.Comments.Add
{
    public class Request : IRequest<Response>
    {
        public int TaskId { get; set; }
        public string Content { get; set; }
    }
}