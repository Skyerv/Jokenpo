using Jokenpo2.Domain.Enums;
using MediatR;

namespace Jokenpo2.Application.Commands
{
    public class RegisterMoveCommand : IRequest<Unit>
    {
        public Guid PlayerId { get; set; }
        public Move Move { get; set; }
    }
}
