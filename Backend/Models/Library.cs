using Backend.Models.Associations;
using Backend.Models.Base;
using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class Library : BaseEntity
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; } = null!;
        public ICollection<Addition> Games { get; set; } = null!;
    }
}
