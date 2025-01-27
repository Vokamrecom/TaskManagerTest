using MediatR;
using System.Security.Claims;
using TaskManager.Data;
using Task = TaskManager.Data.Task;

namespace TaskManager.Application.Tasks.Create
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly TaskManagerDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Handler(TaskManagerDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out var userId))
            {
                return new Response { Success = false};
            }

            var task = new Task
            {
                UserId = (int)userId,
                Title = request.Title,
                Description = request.Description,
                CreatedAt = DateTime.UtcNow,
                Status = Enums.TaskStatus.Created,
                EstimatedCompletion = request.EstimatedCompletion
            };

            _dbContext.Tasks.Add(task);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new Response { TaskId = task.Id, Success = true };
        }
    }
}
