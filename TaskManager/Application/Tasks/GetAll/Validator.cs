using FluentValidation;

namespace TaskManager.Application.Tasks.GetAll
{
    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.Status).NotEmpty().WithMessage("Status cannot be empty.");
        }
    }
}
