using MediatR;

namespace Jokenpo2.Application.Commands
{
    public class RemovePlayerCommand : IRequest<bool>
    {
        public Guid PlayerId { get; set; }
    }
}
