using MediatR;
using TaskManager.Data;

namespace TaskManager.Application.Tasks.Get
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
            var task = await _context.Tasks
                .FindAsync(request.TaskId);
            if (task == null)
            {
                return new Response { Success = false, Message = "Task not found." };
            }

            return new Response
            {
                Success = true,
                Task = new TaskDto
                {
                    Id = task.Id,
                    Title = task.Title,
                    Description = task.Description,
                    Status = task.Status,
                    CreatedAt = task.CreatedAt,
                    EstimatedCompletion = task.EstimatedCompletion,
                    ActualCompletion = task.ActualCompletion,
                    //CreatedBy = task.User.Username
                }
            };
        }
    }
}
