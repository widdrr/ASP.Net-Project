namespace Backend.Models.DTOs.Transactions
{
    public class GamePurchaseDto
    {
        public Guid GameId { get; set; }
        public string? GameName { get; set; }
        public double Price { get; set; }
    }
}
