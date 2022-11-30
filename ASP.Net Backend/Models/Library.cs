using ASP.Net_Backend.Models.Associations;
using ASP.Net_Backend.Models.Base;

namespace ASP.Net_Backend.Models
{
    public class Library : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public ICollection<GameLibrary>? GameLibraries { get; set; }
    }
}
