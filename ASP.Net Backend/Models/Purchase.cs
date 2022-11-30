using ASP.Net_Backend.Models.Associations;
using Microsoft.EntityFrameworkCore;

namespace ASP.Net_Backend.Models
{
    public class Purchase
    {
        public Guid TransactionId { get; set; }
        public Transaction Transaction { get; set; } = null!;
        public ICollection<GamePurchase> GamePurchases { get; set; } = null!;
    }
}
