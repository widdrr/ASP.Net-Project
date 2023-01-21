using System.Text.Json.Serialization;

namespace Backend.Models.DTOs.Transactions
{
    public class TransactionDto
    {
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; } = "Error";
        public double Sum { get; set; }
        public Guid Id { get; set; }
    }
}
