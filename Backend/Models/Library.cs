using Backend.Models.Associations;
using Backend.Models.Base;

namespace Backend.Models
{
    public class Library : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public ICollection<Addition> GameLibraries { get; set; } = null!;
    }
}
