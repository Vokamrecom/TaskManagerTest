using FluentValidation;

namespace TaskManager.Application.Users.Register
{
    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username cannot be empty.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password cannot be empty.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty.");
        }
    }
}