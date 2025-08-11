using Jokenpo2.Domain.Enums;

namespace Jokenpo2.Application.Services
{
    public class JokenpoService
    {
        public Dictionary<Guid, string> Players { get; } = new();
        public Dictionary<Guid, Move> Moves { get; } = new();

        private readonly int[] victoryMask = new int[5]
  {
        (1 << (int)Move.Scissors) | (1 << (int)Move.Lizard), 
        (1 << (int)Move.Rock)   | (1 << (int)Move.Spock),   
        (1 << (int)Move.Paper)   | (1 << (int)Move.Lizard),
        (1 << (int)Move.Paper)   | (1 << (int)Move.Spock),   
        (1 << (int)Move.Rock)   | (1 << (int)Move.Scissors)
  };

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


        public (Guid winnerId, string winnerName)? EndRound()
        {
            if (Players.Count == 0 || Moves.Count < Moves.Count)
                return null;

            int[] count = new int[5];
            foreach (var move in Moves.Values)
                count[(int)move]++;

            var points = Players.Keys.ToDictionary(id => id, _ => 0);

            foreach (var player in Moves.Keys)
            {
                var currMove = Moves[player];
                int mask = victoryMask[(int)currMove];
                int score = 0;

                for (int j = 0; j < 5; j++)
                {
                    if ((mask & (1 << j)) != 0)
                        score += count[j];
                }

                points[player] = score;
            }

            var winner = points.OrderByDescending(p => p.Value).First();
            return (winner.Key, Players[winner.Key]);
        }

        public void ClearRound() => Moves.Clear();
    }
}
