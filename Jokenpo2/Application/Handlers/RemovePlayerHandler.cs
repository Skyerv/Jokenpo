using Jokenpo2.Application.Commands;
using Jokenpo2.Application.Services;
using MediatR;

namespace Jokenpo2.Application.Handlers
{
    public class RemovePlayerHandler : IRequestHandler<RemovePlayerCommand, bool>
    {
        private readonly JokenpoService _service;

        public RemovePlayerHandler(JokenpoService service)
        {
            _service = service;
        }

        public Task<bool> Handle(RemovePlayerCommand request, CancellationToken cancellationToken)
        {
            var result = _service.RemovePlayer(request.PlayerId);
            return Task.FromResult(result);
        }
    }
}
