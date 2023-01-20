using Backend.Data;
using Backend.Models;
using Backend.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories.TransactionRepository
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        private readonly DbSet<Deposit> _deposits;
        private readonly DbSet<Purchase> _purchases;
        public TransactionRepository(GameStoreContext gameStoreContext) : base(gameStoreContext)
        {
            _deposits = _context.Deposits;
            _purchases = _context.Purchases;
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsForUser(Guid userId)
        {
            return await _table.AsNoTracking()
                        .Include(t => t.Deposit)
                        .Include(t => t.Purchase)
                        .ThenInclude(p => p!.GamePurchases)
                        .Where(t => t.UserId == userId)
                        .ToListAsync();
        }
        public async Task<IEnumerable<Deposit>> GetDepositsForUser(Guid userId)
        {
            return await _deposits.AsNoTracking()
                .Include(d => d.Transaction)
                .Where(d => d.Transaction.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Purchase>> GetPurchasesForUser(Guid userId)
        {
            return await _purchases.AsNoTracking()
                .Include(p => p.Transaction)
                .Where(p => p.Transaction.UserId == userId)
                .Include(p => p.GamePurchases)
                .ToListAsync();
        }

    }
}
