using ASP.Net_Backend.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ASP.Net_Backend.Models
{
    public class User : BaseEntity
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        [JsonIgnore]
        public string? PasswordHash { get; set; }
        public DateTime JoinDate { get; set; }
        public Library? Library { get; set; }
        public ICollection<Transaction> Transactions { get; set; } = null!;

    }
}
