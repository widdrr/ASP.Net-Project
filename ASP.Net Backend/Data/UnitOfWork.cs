using ASP.Net_Backend.Models.Base;
using ASP.Net_Backend.Repositories;
using ASP.Net_Backend.Repositories.BaseRepository;
using ASP.Net_Backend.Repositories.GameRepository;
using ASP.Net_Backend.Repositories.TransactionRepository;
using ASP.Net_Backend.Repositories.UserRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.SqlClient;

namespace ASP.Net_Backend.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GameStoreContext _context;
        private IDbContextTransaction? _transaction;
        /*
         * Choosing to hardcode my repositories instead of
         * using a more generic dictionary approach or similar
         * because there's only a few of them and the general
         * approach is more complicated
         */
        private IGameRepository? _gameRepository;
        private IUserRepository? _userRepository;
        private ITransactionRepository? _transactionRepository;

        public UnitOfWork(GameStoreContext context)
        {
            _context = context;
        }

        public GameStoreContext Context
        {
            get { return _context; }
        }
        public IGameRepository GameRepository
        {
            get
            {
                if(_gameRepository is null)
                {
                    _gameRepository = new GameRepository(_context);
                }
                return _gameRepository;
            }
        }
        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository is null)
                {
                    _userRepository = new UserRepository(_context);
                }
                return _userRepository;
            }
        }
        public ITransactionRepository TransactionRepository
        {
            get
            {
                if (_transactionRepository is null)
                {
                    _transactionRepository = new TransactionRepository(_context);
                }
                return _transactionRepository;
            }
        }
        public async Task CreateTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            await _transaction!.CommitAsync();
        }
        public async Task RollbackAsync()
        {
            await _transaction!.RollbackAsync();
        }
        public async Task SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }
        }
        
    }
}
