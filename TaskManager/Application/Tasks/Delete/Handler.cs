using MediatR;
using TaskManager.Data;

namespace TaskManager.Application.Tasks.Delete
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

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync(cancellationToken);

            return new Response { Success = true, Message = "Task deleted successfully." };
        }
    }
}
