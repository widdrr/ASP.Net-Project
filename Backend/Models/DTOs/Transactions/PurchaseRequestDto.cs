namespace Backend.Models.DTOs.Transactions
{
    public class PurchaseRequestDto
    {
        public IEnumerable<GamePurchaseDto> Purchases { get; set; } = null!;
    }
}
