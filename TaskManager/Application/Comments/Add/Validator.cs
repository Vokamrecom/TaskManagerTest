using FluentValidation;

namespace TaskManager.Application.Comments.Add
{
    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage("Content cannot be empty.");
            RuleFor(x => x.TaskId).GreaterThan(0).WithMessage("Invalid task ID.");
        }
    }
}
