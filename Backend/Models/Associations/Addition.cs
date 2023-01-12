namespace Backend.Models.Associations
{
    public class Addition
    {
        public Guid GameId { get; set; }
        public Game Game { get; set; } = null!;
        public DateTime DateAdded { get; set; }
        public Guid LibraryId { get; set; }
        public Library Library { get; set; } = null!;
    }
}
