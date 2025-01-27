using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Tasks.Get;
using TaskManager.Data;

namespace TaskManager.Application.Tasks.GetAll
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
            var tasksQuery = _context.Tasks.AsQueryable();

            //if (request.Status != null)
            //{
            //    tasksQuery = tasksQuery.Where(t => t.Status == request.Status);
            //}

            if (request.UserId != null)
            {
                tasksQuery = tasksQuery.Where(t => t.UserId == request.UserId);
            }

            if (request.StartDate.HasValue)
            {
                tasksQuery = tasksQuery.Where(t => t.CreatedAt >= request.StartDate.Value);
            }

            if (request.EndDate.HasValue)
            {
                tasksQuery = tasksQuery.Where(t => t.CreatedAt <= request.EndDate.Value);
            }

            var tasks = await tasksQuery.Include(x=>x.User).ToListAsync(cancellationToken);

            return new Response
            {
                Tasks = tasks.Select(t => new TaskDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    Status = (Enums.TaskStatus)t.Status,
                    CreatedAt = t.CreatedAt,
                    CreatedBy = t.User.Username
                }).ToList()
            };
        }

    }
}
