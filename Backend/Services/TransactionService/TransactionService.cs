using Backend.Data;
using Backend.Helpers.Authorization;
using Backend.Models;
using Backend.Models.DTOs;
using Backend.Models.DTOs.Transactions;
using Backend.Repositories.TransactionRepository;
using Backend.Repositories.UserRepository;
using Backend.Services.GameService;
using Backend.Services.UserService;

namespace Backend.Services.TransactionService
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly IGameService _gameService;
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(IUnitOfWork unitOfWOrk, IUserService userService, IGameService gameService)
        {
            _unitOfWork = unitOfWOrk;
            _transactionRepository = _unitOfWork.TransactionRepository;
            _userService = userService;
            _gameService = gameService;
        }

        public async Task<IEnumerable<TransactionDto>> GetTransactionsForUserAsync(Guid userId)
        {
            return await _transactionRepository.GetTransactionsForUserAsync(userId);
        }
        public async Task<IEnumerable<TransactionDto>> GetDepositsForUserAsync(Guid userId)
        {
            return await _transactionRepository.GetDepositsForUserAsync(userId);
        }

        public async Task<IEnumerable<TransactionDto>> GetPurchasesForUserAsync(Guid userId)
        {
            return await _transactionRepository.GetPurchasesForUserAsync(userId);
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
            var games = await _gameService.GetByIdRangeAsync(purchase.Games);
            var newTransaction = new Transaction(userId, games);

            var purchaseCost = newTransaction.Purchase!.GamePurchases.Sum(gp => gp.Price);

            var accountBalance = await _userService.GetAccountBalanceAsync(userId);
            if (purchaseCost > accountBalance)
                return null;


            return await CreateTransactionAsync(newTransaction);
        }
    }
}
