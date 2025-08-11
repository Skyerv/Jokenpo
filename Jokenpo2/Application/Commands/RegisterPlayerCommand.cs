using MediatR;

namespace Jokenpo2.Application.Commands
{
    public class RegisterPlayerCommand : IRequest<Guid>
    {
        public string Name { get; set; } = null!;
    }
}
