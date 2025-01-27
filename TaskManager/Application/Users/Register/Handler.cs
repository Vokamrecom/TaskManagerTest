using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data;

namespace TaskManager.Application.Users.Register
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly TaskManagerDbContext _context;

        public Handler(TaskManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == request.Username, cancellationToken);
            if (existingUser != null)
            {
                return new Response { Success = false, Message = "User already exists." };
            }

            var newUser = new User
            {
                Username = request.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Name = request.Name
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync(cancellationToken);

            return new Response { Success = true, Message = "User registered successfully." };
        }
    }
}
