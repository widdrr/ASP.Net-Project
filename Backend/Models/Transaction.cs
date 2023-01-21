using Backend.Models.Associations;
using Backend.Models.Base;
using Backend.Models.DTOs;
using Backend.Models.DTOs.Transactions;
using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class Transaction : BaseEntity
    {
        public Guid UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; } = null!;
        public DateTime Date { get; set; }
        public Purchase? Purchase { get; set; }
        public Deposit? Deposit { get; set; }

        public Transaction() {}
        public Transaction(Guid userId, double depositSum) 
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Date = DateTime.Now;
            Deposit = new Deposit
            {
                TransactionId = Id,
                Transaction = this,
                Sum = depositSum,
            };
            Purchase = null;
        }
        public Transaction(Guid userId, IEnumerable<Game> purchase)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Date = DateTime.Now;
            Purchase = new Purchase
            {
                TransactionId = Id,
                Transaction = this,
                GamePurchases = purchase.Select(game => new GamePurchase
                    {
                        GameId = game.Id,
                        Price = game.Price,
                        TransactionId = Id,
                    }).ToList()
            };
            Deposit = null; 
        }
    }

}
