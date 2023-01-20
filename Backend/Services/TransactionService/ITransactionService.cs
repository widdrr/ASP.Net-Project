using Backend.Models;
using Backend.Models.DTOs;
using Backend.Models.DTOs.Transactions;

namespace Backend.Services.TransactionService
{
    public interface ITransactionService
    {
        Task<IEnumerable<Transaction>> GetTransactionsForUser(Guid userId);
        Task<IEnumerable<Deposit>> GetDepositsForUser(Guid userId);
        Task<IEnumerable<Purchase>> GetPurchasesForUser(Guid userId);
        Task<Transaction?> MakeDepositAsync(Guid userId, double depositSum);
        Task<Transaction?> MakePurchaseAsync(Guid userId, PurchaseRequestDto purchase);
        Task<Transaction?> CreateTransactionAsync(Transaction transaction);
    }
}
