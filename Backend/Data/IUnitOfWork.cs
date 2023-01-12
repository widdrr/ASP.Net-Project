using ASP.Net_Backend.Repositories.GameRepository;
using ASP.Net_Backend.Repositories.TransactionRepository;
using ASP.Net_Backend.Repositories.UserRepository;
using Microsoft.EntityFrameworkCore;

namespace ASP.Net_Backend.Data
{
    public interface IUnitOfWork
    {
        GameStoreContext Context { get; }
        IGameRepository GameRepository { get; }
        IUserRepository UserRepository { get; }
        ITransactionRepository TransactionRepository { get; }
        Task CreateTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
        Task SaveAsync();
    }
}
