namespace Backend.Models.DTOs.Transactions
{
    public class DetailedTransactionDto
    {
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; } = "Error";
        public double Sum { get; set; }
        public IEnumerable<GamePurchaseDto>? Games { get; set; }
        public Guid Id { get; set; }
    }
}
