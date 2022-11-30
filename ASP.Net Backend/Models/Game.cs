using ASP.Net_Backend.Models.Associations;
using ASP.Net_Backend.Models.Base;

namespace ASP.Net_Backend.Models
{
    public class Game : BaseEntity
    {
        public string? Name { get; set; }
        public string? Developer { get; set; }
        public int? Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ICollection<GameLibrary> GameLibraries { get; set; } = null!;
        public ICollection<GameTransaction> GameTransactions { get; set; } = null!;
    }
}
