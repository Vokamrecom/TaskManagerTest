using MediatR;

namespace TaskManager.Application.Tasks.Create
{
    public class Request : IRequest<Response>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EstimatedCompletion { get; set; }
    }
}
