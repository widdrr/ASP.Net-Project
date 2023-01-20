using Backend.Models.DTOs.Transactions;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Backend.Models.Associations
{
    public class GamePurchase
    {
        public Guid GameId { get; set; }
        [JsonIgnore]
        public Game Game { get; set; } = null!;
        [Range(0,999)]
        public double Price { get; set; }
        [JsonIgnore]
        public Guid TransactionId { get; set; }
        [JsonIgnore]
        public Purchase Purchase { get; set; } = null!;

    }
}
