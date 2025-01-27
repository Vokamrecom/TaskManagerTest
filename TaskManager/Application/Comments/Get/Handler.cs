using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data;

namespace TaskManager.Application.Comments.Get
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
            var task = await _context.Tasks.FindAsync(request.TaskId);
            if (task == null)
            {
                return new Response { Success = false, Message = "Task not found." };
            }

            var comments = await _context.Comments
                .Include(x=>x.Task.User)
                .Where(c => c.TaskId == request.TaskId)
                .ToListAsync(cancellationToken);

            return new Response
            {
                Success = true,
                Comments = comments.Select(c => new CommentDto
                {
                    UserName = c.Task.User.Username,
                    Content = c.Content,
                    CreatedAt = c.CreatedAt
                }).ToList()
            };
        }
    }
}
