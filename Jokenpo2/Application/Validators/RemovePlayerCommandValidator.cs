using FluentValidation;
using Jokenpo2.Application.Commands;

namespace Jokenpo2.Application.Validators
{
    public class RemovePlayerCommandValidator : AbstractValidator<RemovePlayerCommand>
    {
        public RemovePlayerCommandValidator()
        {
            RuleFor(x => x.PlayerId)
                .NotEmpty().WithMessage("PlayerId must be provided and not empty.");
        }
    }
}
