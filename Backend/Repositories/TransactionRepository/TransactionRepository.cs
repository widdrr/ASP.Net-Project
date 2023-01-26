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
        private readonly DbSet<Purchase> _purchases;
        private readonly DbSet<GamePurchase> _gamePurchases;
        public TransactionRepository(GameStoreContext gameStoreContext) : base(gameStoreContext)
        {
            _deposits = _context.Deposits;
            _gamePurchases = _context.GamePurchases;
            _purchases = _context.Purchases;
        }

        public async Task<DetailedTransactionDto?> GetTransactionDetailsAsync(Guid transactionId)
        {
            var deposit = await _deposits.Where(d => d.TransactionId == transactionId)
                          .Select(d => new DetailedTransactionDto
                          {
                              Id = d.Transaction.Id,
                              UserId = d.Transaction.UserId,
                              Date = d.Transaction.Date,
                              Type = "Deposit",
                              Sum = d.Sum
                          }).FirstOrDefaultAsync();

            if (deposit != null)
                return deposit;

            var purchase = await (from t in _table.AsNoTracking()
                                  where t.Id == transactionId
                                  join gp in _gamePurchases.Include(gp => gp.Game)
                                    on t.Id equals gp.TransactionId
                                    into purchases
                                  select new DetailedTransactionDto
                                  {
                                      Id = t.Id,
                                      UserId = t.UserId,
                                      Date = t.Date,
                                      Type = "Purchase",
                                      Sum = purchases.Sum(p => p.Price),
                                      Games = purchases.Select(game => new GamePurchaseDto(game))
                                  }).FirstOrDefaultAsync();

            return purchase;
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
            return await (from t in _purchases.AsNoTracking()
                          where t.Transaction.UserId == userId
                          join gp in _gamePurchases
                            on t.Transaction.Id equals gp.TransactionId
                            into purchases
                          select new TransactionDto
                          {
                              Id = t.Transaction.Id,
                              UserId = t.Transaction.UserId,
                              Date = t.Transaction.Date,
                              Type = "Purchase",
                              Sum = purchases.Sum(p => p.Price)
                          })
                          .ToListAsync();      
        }

        public async Task<IDictionary<string,double>> GetGroupedSums(Guid userId)
        {
            var transactions = GetTransactionsForUserAsync(userId);

            var groupedSum = (await transactions)
                             .GroupBy(
                              t => t.Type,
                              (type, transactions) => new
                              {
                                  Type = type,
                                  Sum = transactions.Sum(t => t.Sum),
                              })
                             .ToDictionary(t => t.Type,
                                           t => t.Sum);
            return groupedSum;
        }
    }
}
