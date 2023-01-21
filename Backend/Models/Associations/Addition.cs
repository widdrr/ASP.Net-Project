using System.Text.Json.Serialization;

namespace Backend.Models.Associations
{
    public class Addition
    {
        public Guid GameId { get; set; }
        [JsonIgnore]
        public Game Game { get; set; } = null!;
        public DateTime DateAdded { get; set; }
        [JsonIgnore]
        public Guid LibraryId { get; set; }
        [JsonIgnore]
        public Library Library { get; set; } = null!;
    }
}
