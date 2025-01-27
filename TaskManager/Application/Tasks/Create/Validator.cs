using FluentValidation;

namespace TaskManager.Application.Tasks.Create
{
    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title cannot be empty.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description cannot be empty.");
        }
    }
}