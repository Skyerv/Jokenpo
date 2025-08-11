namespace Jokenpo2.Domain.DTO
{
    public class RoundStatusDTO
    {
        public List<PlayerDTO> Players { get; set; } = new();
        public List<PlayerDTO> Played { get; set; } = new();
        public List<PlayerDTO> NotPlayed { get; set; } = new();
    }
}
