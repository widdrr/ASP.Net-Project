using ASP.Net_Backend.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ASP.Net_Backend.Models
{
    public class User : BaseEntity
    {
        [StringLength(64)]
        public string Username { get; set; } = null!;
        [StringLength(64)]
        public string Email { get; set; } = null!;
        [JsonIgnore]
        public string PasswordHash { get; set; } = null!;
        public DateTime JoinDate { get; set; }
        public Library? Library { get; set; }
        public ICollection<Transaction>? Transactions { get; set; }

    }
}
