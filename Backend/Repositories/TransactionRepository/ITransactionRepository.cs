using Backend.Models;
using Backend.Repositories.BaseRepository;

namespace Backend.Repositories.TransactionRepository
{
    public interface ITransactionRepository : IBaseRepository<Transaction>
    {
        Task<IEnumerable<Transaction>> GetTransactionsForUser(Guid userId);
        Task<IEnumerable<Deposit>> GetDepositsForUser(Guid userId);
        Task<IEnumerable<Purchase>> GetPurchasesForUser(Guid userId);
    }
}
