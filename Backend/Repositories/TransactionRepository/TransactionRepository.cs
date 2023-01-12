using Backend.Data;
using Backend.Models;
using Backend.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories.TransactionRepository
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
