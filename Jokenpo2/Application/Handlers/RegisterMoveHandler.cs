using Jokenpo2.Application.Commands;
using Jokenpo2.Application.Services;
using MediatR;


namespace Jokenpo2.Application.Handlers
{
    public class RegisterMoveHandler : IRequestHandler<RegisterMoveCommand, Unit>
    {
        private readonly JokenpoService _service;

        public RegisterMoveHandler(JokenpoService service)
        {
            _service = service;
        }

        public Task<Unit> Handle(RegisterMoveCommand request, CancellationToken cancellationToken)
        {
            _service.RegisterMove(request.PlayerId, request.Move);
            return Task.FromResult(Unit.Value);
        }
    }
}
