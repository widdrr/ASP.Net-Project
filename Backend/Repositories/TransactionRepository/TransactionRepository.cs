using ASP.Net_Backend.Data;
using ASP.Net_Backend.Models;
using ASP.Net_Backend.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace ASP.Net_Backend.Repositories.TransactionRepository
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(GameStoreContext gameStoreContext) : base(gameStoreContext)
        { }

        public async Task<IEnumerable<Transaction>> getDepositsForUser(Guid userId)
        {
            return await _table
                .Where(t => t.UserId == userId)
                .Include(t => t.Deposit)
                .Where(t => t.Deposit != null)
                .ToListAsync();
        }

        public async Task<IEnumerable<Transaction>> getPurchasesForUser(Guid userId)
        {
            return await _table
                .Where(t => t.UserId == userId)
                .Include(t => t.Purchase)
                .ThenInclude(p => p.GamePurchases)
                .ToListAsync();
        }
    }
}
