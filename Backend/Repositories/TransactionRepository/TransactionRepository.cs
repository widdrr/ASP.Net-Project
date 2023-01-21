using Backend.Data;
using Backend.Models;
using Backend.Models.Associations;
using Backend.Models.DTOs.Transactions;
using Backend.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories.TransactionRepository
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        private readonly DbSet<Deposit> _deposits;
        private readonly DbSet<GamePurchase> _gamePurchases;
        public TransactionRepository(GameStoreContext gameStoreContext) : base(gameStoreContext)
        {
            _deposits = _context.Deposits;
            _gamePurchases = _context.GamePurchases;
        }

        public async Task<IEnumerable<TransactionDto>> GetTransactionsForUserAsync(Guid userId)
        {
            var deposits = await GetDepositsForUserAsync(userId);
            var purchases = await GetPurchasesForUserAsync(userId);

            return deposits.Union(purchases);
        }
        public async Task<IEnumerable<TransactionDto>> GetDepositsForUserAsync(Guid userId)
        {
            return await (from t in _table.AsNoTracking()
                         where t.UserId == userId
                         join d in _deposits
                            on t.Id equals d.TransactionId
                         select new TransactionDto
                         {  
                            Id = t.Id,
                            UserId = t.UserId,
                            Date = t.Date,
                            Type = "Deposit",
                            Sum = d.Sum
                         })
                         .ToListAsync();
        }

        public async Task<IEnumerable<TransactionDto>> GetPurchasesForUserAsync(Guid userId)
        {
            return await (from t in _table.AsNoTracking()
                          where t.UserId == userId
                          join gp in _gamePurchases
                            on t.Id equals gp.TransactionId
                            into purchases
                          select new TransactionDto
                          {
                              Id = t.Id,
                              UserId = t.UserId,
                              Date = t.Date,
                              Type = "Purchase",
                              Sum = purchases.Sum(p => p.Price)
                          })
                          .ToListAsync();      
        }

    }
}
