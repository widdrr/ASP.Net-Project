using Backend.Models;
using Backend.Models.DTOs;
using Backend.Models.DTOs.Transactions;

namespace Backend.Services.TransactionService
{
    public interface ITransactionService
    {
        Task<DetailedTransactionDto?> GetTransactionByIdAsync(Guid transactionId);
        Task<IEnumerable<TransactionDto>> GetTransactionsForUserAsync(Guid userId);
        Task<IEnumerable<TransactionDto>> GetDepositsForUserAsync(Guid userId);
        Task<IEnumerable<TransactionDto>> GetPurchasesForUserAsync(Guid userId);
        Task<Transaction?> MakeDepositAsync(Guid userId, double depositSum);
        Task<Transaction?> MakePurchaseAsync(Guid userId, PurchaseRequestDto purchase);
        Task<Transaction?> CreateTransactionAsync(Transaction transaction);
    }
}
