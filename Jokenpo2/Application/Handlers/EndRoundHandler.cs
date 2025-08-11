using Jokenpo2.Application.Commands;
using Jokenpo2.Application.Services;
using MediatR;

namespace Jokenpo2.Application.Handlers
{
    public class EndRoundHandler : IRequestHandler<EndRoundCommand, (Guid winnerId, string winnerName)?>
    {
        private readonly JokenpoService _jokenpoService;

        public EndRoundHandler(JokenpoService jokenpoService)
        {
            _jokenpoService = jokenpoService;
        }

        public Task<(Guid winnerId, string winnerName)?> Handle(EndRoundCommand request, CancellationToken cancellationToken)
        {
            var result = _jokenpoService.EndRound();

            if (result != null)
                _jokenpoService.ClearRound();

            return Task.FromResult(result);
        }
    }
}
