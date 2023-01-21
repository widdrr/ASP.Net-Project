using Backend.Models;
using Backend.Models.DTOs.Transactions;
using Backend.Repositories.BaseRepository;

namespace Backend.Repositories.TransactionRepository
{
    public interface ITransactionRepository : IBaseRepository<Transaction>
    {
        Task<IEnumerable<TransactionDto>> GetTransactionsForUserAsync(Guid userId);
        Task<IEnumerable<TransactionDto>> GetDepositsForUserAsync(Guid userId);
        Task<IEnumerable<TransactionDto>> GetPurchasesForUserAsync(Guid userId);
    }
}
