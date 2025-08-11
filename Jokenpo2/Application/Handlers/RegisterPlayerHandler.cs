using Jokenpo2.Application.Commands;
using Jokenpo2.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Jokenpo2.Application.Handlers
{
    public class RegisterPlayerHandler : IRequestHandler<RegisterPlayerCommand, Guid>
    {
        private readonly JokenpoService _service;

        public RegisterPlayerHandler(JokenpoService service)
        {
            _service = service;
        }

        public Task<Guid> Handle(RegisterPlayerCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            _service.RegisterPlayer(id, request.Name);
            return Task.FromResult(id);
        }
    }
}
