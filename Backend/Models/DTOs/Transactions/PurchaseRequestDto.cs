namespace Backend.Models.DTOs.Transactions
{
    public class PurchaseRequestDto
    {
        public IEnumerable<Guid> Games { get; set; } = null!;
    }
}
