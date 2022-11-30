using System.ComponentModel.DataAnnotations;

namespace ASP.Net_Backend.Models
{
    public class Deposit
    {
        public Guid TransactionId { get; set; }
        public Transaction Transaction { get; set; } = null!;
        [Range(0, 999)]
        public int Sum { get; set; }
    }
}
