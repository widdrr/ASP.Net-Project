using Backend.Data;
using Backend.Helpers.Authorization;
using Backend.Models;
using Backend.Models.Associations;
using Backend.Models.DTOs;
using Backend.Models.DTOs.Transactions;
using Backend.Repositories.TransactionRepository;
using Backend.Repositories.UserRepository;
using Backend.Services.GameService;
using Backend.Services.LibraryService;
using Backend.Services.UserService;

namespace Backend.Services.TransactionService
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly IGameService _gameService;
        private readonly ILibraryService _libraryService;
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(IUnitOfWork unitOfWOrk, 
                                  IUserService userService, 
                                  IGameService gameService, 
                                  ILibraryService libraryService)
        {
            _unitOfWork = unitOfWOrk;
            _transactionRepository = _unitOfWork.TransactionRepository;
            _userService = userService;
            _gameService = gameService;
            _libraryService = libraryService;
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
            //Would be nice to switch to throwing exceptions instead of returning null
            //might do it if I have enough time
            var games = await _gameService.GetByIdRangeAsync(purchase.Games);
            var newTransaction = new Transaction(userId, games);

            var purchaseCost = newTransaction.Purchase!.GamePurchases.Sum(gp => gp.Price);

            var accountBalance = await _userService.GetAccountBalanceAsync(userId);
            if (purchaseCost > accountBalance)
                return null;

            var library = await _libraryService.GetByOwnerAsync(userId);

            if(library == null)
                return null;

            var libraryGames = library.Games.Select(g => g.GameId).ToHashSet();
            foreach (var game in games)
            {
                if (libraryGames.Contains(game.Id))
                    return null;

                library.Games.Add(new Addition
                {
                    GameId = game.Id,
                    DateAdded = DateTime.Now,
                    LibraryId = library.Id
                }); 
            }

            return await CreateTransactionAsync(newTransaction);
        }
    }
}
