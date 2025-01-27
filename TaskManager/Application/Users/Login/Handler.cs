using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TaskManager.Data;

namespace TaskManager.Application.Users.Login
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly TaskManagerDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Handler(TaskManagerDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == request.Username, cancellationToken);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return new Response { Success = false, Message = "Invalid credentials." };
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var identity = new ClaimsIdentity(claims, "login");
            var principal = new ClaimsPrincipal(identity);

            await _httpContextAccessor.HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties
                {
                    IsPersistent = true, 
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(30) 
                });

            return new Response { Success = true, Message = "Login successful." };
        }
    }
}
