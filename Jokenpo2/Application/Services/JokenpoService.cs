using Jokenpo2.Domain.Enums;

namespace Jokenpo2.Application.Services
{
    public class JokenpoService
    {
        public Dictionary<Guid, string> Players { get; } = new();
        public Dictionary<Guid, Move> Moves { get; } = new();

        public bool RegisterPlayer(Guid id, string name)
        {
            if (Players.ContainsKey(id))
                return false;

            Players[id] = name;
            return true;
        }
        public void RegisterMove(Guid playerId, Move move)
        {
            if (!Players.ContainsKey(playerId))
                throw new ArgumentException("Player does not exist.");

            Moves[playerId] = move;
        }
    }
}
