using Backend.Models.Associations;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    public class Purchase
    {
        public Guid TransactionId { get; set; }
        public Transaction Transaction { get; set; } = null!;
        public ICollection<GamePurchase> GamePurchases { get; set; } = null!;
    }
}
