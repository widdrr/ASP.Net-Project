using Backend.Models.Associations;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class Purchase
    {
        [JsonIgnore]
        public Guid TransactionId { get; set; }
        [JsonIgnore]
        public Transaction Transaction { get; set; } = null!;
        public ICollection<GamePurchase> GamePurchases { get; set; } = null!;
    }
}
