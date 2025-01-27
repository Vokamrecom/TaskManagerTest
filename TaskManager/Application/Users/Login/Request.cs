using MediatR;

namespace TaskManager.Application.Users.Login
{
    public class Request : IRequest<Response>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
