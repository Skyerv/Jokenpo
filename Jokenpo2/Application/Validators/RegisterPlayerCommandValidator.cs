using FluentValidation;
using Jokenpo2.Application.Commands;

namespace Jokenpo2.Application.Validators
{
    public class RegisterPlayerCommandValidator : AbstractValidator<RegisterPlayerCommand>
    {
        public RegisterPlayerCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        }
    }
}
