using Backend.Data;
using Backend.Helpers.Authorization;
using Backend.Models;
using Backend.Models.DTOs;
using Backend.Models.DTOs.Transactions;
using Backend.Repositories.TransactionRepository;
using Backend.Repositories.UserRepository;
using Backend.Services.UserService;

namespace Backend.Services.TransactionService
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(IUnitOfWork unitOfWOrk, IUserService userService)
        {
            _unitOfWork = unitOfWOrk;
            _transactionRepository = _unitOfWork.TransactionRepository;
            _userService = userService;
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsForUser(Guid userId)
        {
            return await _transactionRepository.GetTransactionsForUser(userId);
        }
        public Task<IEnumerable<Deposit>> GetDepositsForUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Purchase>> GetPurchasesForUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Transaction?> CreateTransactionAsync(Transaction transaction)
        {
            await _transactionRepository.CreateAsync(transaction);

            try
            {
                await _unitOfWork.SaveAsync();
            }
            catch(Exception)
            {
                return null;
            }
            return transaction;
        }

        public async Task<Transaction?> MakeDepositAsync(Guid userId, double deposit)
        {
            var newTransaction = new Transaction(userId,deposit);

            return await CreateTransactionAsync(newTransaction);
        }

        public async Task<Transaction?> MakePurchaseAsync(Guid userId, PurchaseRequestDto purchase)
        {
            var newTransaction = new Transaction(userId, purchase);

            var purchaseCost = newTransaction.Purchase!.GamePurchases.Sum(gp => gp.Price);

            var accountBalance = await _userService.GetAccountBalanceAsync(userId);
            if (purchaseCost > accountBalance)
                return null;

            return await CreateTransactionAsync(newTransaction);
        }
    }
}
