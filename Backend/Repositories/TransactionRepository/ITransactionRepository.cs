using Backend.Models;
using Backend.Repositories.BaseRepository;

namespace Backend.Repositories.TransactionRepository
{
    public interface ITransactionRepository : IBaseRepository<Transaction>
    {
        Task<IEnumerable<Transaction>> getDepositsForUser(Guid userId);
        Task<IEnumerable<Transaction>> getPurchasesForUser(Guid userId);
    }
}
