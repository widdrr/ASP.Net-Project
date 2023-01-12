namespace ASP.Net_Backend.Models.DTOs.Games
{
    public class GameRequestDto
    {
        public string Name { get; set; } = null!;
        public string Developer { get; set; } = null!;
        public double Price { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
