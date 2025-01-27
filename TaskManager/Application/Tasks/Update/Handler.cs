using MediatR;
using TaskManager.Data;

namespace TaskManager.Application.Tasks.Update
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

            task.Status = request.Status;
            task.Title = request.Title;
            task.ActualCompletion = request.ActualCompletion;
            task.Description = request.Description;

            _context.Tasks.Update(task);
            await _context.SaveChangesAsync(cancellationToken);

            return new Response { Success = true, Message = "Task updated successfully." };
        }
    }
}
