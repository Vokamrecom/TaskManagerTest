using FluentValidation;

namespace TaskManager.Application.Tasks.Get
{
    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.TaskId).GreaterThan(0).WithMessage("TaskId should be greater than 0.");
        }
    }
}
