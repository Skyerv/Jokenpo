using Jokenpo2.Application.Queries;
using Jokenpo2.Application.Services;
using Jokenpo2.Domain.DTO;
using MediatR;

namespace Jokenpo2.Application.Handlers
{
    public class GetRoundStatusHandler : IRequestHandler<GetRoundStatusQuery, RoundStatusDTO>
    {
        private readonly JokenpoService _service;

        public GetRoundStatusHandler(JokenpoService service)
        {
            _service = service;
        }

        public Task<RoundStatusDTO> Handle(GetRoundStatusQuery request, CancellationToken cancellationToken)
        {
            var players = _service.Players
                .Select(p => new PlayerDTO { Id = p.Key, Name = p.Value })
                .ToList();

            var played = _service.Moves.Keys
                .Select(id => new PlayerDTO { Id = id, Name = _service.Players[id] })
                .ToList();

            var notPlayed = players
                .Where(p => !_service.Moves.ContainsKey(p.Id))
                .ToList();

            return Task.FromResult(new RoundStatusDTO
            {
                Players = players,
                Played = played,
                NotPlayed = notPlayed
            });
        }
    }
}
