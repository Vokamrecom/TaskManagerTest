using FluentValidation;

namespace TaskManager.Application.Comments.Get
{
    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.TaskId).GreaterThan(0).WithMessage("TaskId should be greater than 0.");
        }
    }
}
