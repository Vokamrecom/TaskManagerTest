using FluentValidation;

namespace TaskManager.Application.Tasks.Update
{
    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.TaskId).GreaterThan(0).WithMessage("TaskId should be greater than 0.");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Status cannot be empty.");
        }
    }
}
