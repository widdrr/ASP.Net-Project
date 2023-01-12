using ASP.Net_Backend.Models.Associations;
using ASP.Net_Backend.Models.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ASP.Net_Backend.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Game : BaseEntity
    {
        [StringLength(64)]
        public string Name { get; set; } = null!;
        [StringLength(64)]
        public string Developer { get; set; } = null!;
        [Range(0,999)]
        public double Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ICollection<Addition>? GameLibraries { get; set; }
        public ICollection<GamePurchase>? GamePurchases { get; set; }
    }
}
