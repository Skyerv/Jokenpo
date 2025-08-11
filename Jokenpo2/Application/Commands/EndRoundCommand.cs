using MediatR;

namespace Jokenpo2.Application.Commands
{
    public class EndRoundCommand : IRequest<(Guid winnerId, string winnerName)?>
    {
    }
}
