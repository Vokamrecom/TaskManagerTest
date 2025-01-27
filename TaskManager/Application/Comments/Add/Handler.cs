using MediatR;
using TaskManager.Data;

namespace TaskManager.Application.Comments.Add
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

            var comment = new Comment
            {
                TaskId = request.TaskId,
                Content = request.Content,
                CreatedAt = DateTime.UtcNow
            };

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync(cancellationToken);

            return new Response { Success = true, Message = "Comment added successfully." };
        }
    }
}