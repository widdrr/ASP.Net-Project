using ASP.Net_Backend.Models;
using ASP.Net_Backend.Repositories.BaseRepository;

namespace ASP.Net_Backend.Repositories.TransactionRepository
{
    public interface ITransactionRepository : IBaseRepository<Transaction>
    {
        Task<IEnumerable<Transaction>> getDepositsForUser(Guid userId);
        Task<IEnumerable<Transaction>> getPurchasesForUser(Guid userId);
    }
}
