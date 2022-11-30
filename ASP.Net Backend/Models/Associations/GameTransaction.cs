namespace ASP.Net_Backend.Models.Associations
{
    public class GameTransaction
    {
        public Guid GameId { get; set; }
        public Game Game { get; set; } = null!;
        public int Sum { get; set; }
        public Guid TransactionId { get; set; }
        public Transaction Transaction { get; set; } = null!;
    }
}
