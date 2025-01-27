using MediatR;

namespace TaskManager.Application.Users.Register
{
    public class Request : IRequest<Response>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}
