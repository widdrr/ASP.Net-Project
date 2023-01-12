namespace Backend.Models.DTOs.Games
{
    public class GameResponseDto
    {
        public string Name { get; set; } = null!;
        public string Developer { get; set; } = null!;
        public double Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Guid Id { get; set; }
    }
}
