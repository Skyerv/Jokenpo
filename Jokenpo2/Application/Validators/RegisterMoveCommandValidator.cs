using FluentValidation;
using Jokenpo2.Application.Commands;
using Jokenpo2.Domain.Enums;

namespace Jokenpo2.Application.Validators
{
    public class RegisterMoveCommandValidator : AbstractValidator<RegisterMoveCommand>
    {
        public RegisterMoveCommandValidator()
        {
            RuleFor(x => x.PlayerId).NotEmpty().WithMessage("PlayerId is required");
            RuleFor(x => x.Move).IsInEnum().WithMessage("Invalid move");
        }
    }
}
