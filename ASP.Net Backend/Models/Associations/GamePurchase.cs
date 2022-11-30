using System.ComponentModel.DataAnnotations;

namespace ASP.Net_Backend.Models.Associations
{
    public class GamePurchase
    {
        public Guid GameId { get; set; }
        public Game Game { get; set; } = null!;
        [Range(0,999)]
        public int Price { get; set; }
        public Guid TransactionId { get; set; }
        public Purchase Purchase { get; set; } = null!;
    }
}
