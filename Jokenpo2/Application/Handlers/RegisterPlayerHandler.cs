using MediatR;
using Jokenpo2.Application.Commands;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Jokenpo2.Application.Handlers
{
    public class RegisterPlayerHandler : IRequestHandler<RegisterPlayerCommand, Guid>
    {
        private static readonly Dictionary<Guid, string> Players = new();

        public Task<Guid> Handle(RegisterPlayerCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            Players[id] = request.Name;
            return Task.FromResult(id);
        }
    }
}
