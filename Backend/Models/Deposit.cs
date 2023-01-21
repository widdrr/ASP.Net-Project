using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class Deposit
    {
        [JsonIgnore]
        public Guid TransactionId { get; set; }
        [JsonIgnore]
        public Transaction Transaction { get; set; } = null!;
        [Range(0, 999)]
        public double Sum { get; set; }
    }
}
