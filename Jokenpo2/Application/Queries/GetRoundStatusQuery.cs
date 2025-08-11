using Jokenpo2.Domain.DTO;
using MediatR;

namespace Jokenpo2.Application.Queries
{
    public class GetRoundStatusQuery : IRequest<RoundStatusDTO>
    {
    }
}
