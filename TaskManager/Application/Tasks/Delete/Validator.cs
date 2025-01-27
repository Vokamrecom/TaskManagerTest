using FluentValidation;

namespace TaskManager.Application.Tasks.Delete
{
    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.TaskId).GreaterThan(0).WithMessage("TaskId should be greater than 0.");
        }
    }
}
