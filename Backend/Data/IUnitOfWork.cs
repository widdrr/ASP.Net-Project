using Backend.Repositories.GameRepository;
using Backend.Repositories.LibraryRepository;
using Backend.Repositories.TransactionRepository;
using Backend.Repositories.UserRepository;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public interface IUnitOfWork
    {
        GameStoreContext Context { get; }
        IGameRepository GameRepository { get; }
        IUserRepository UserRepository { get; }
        ITransactionRepository TransactionRepository { get; }
        ILibraryRepository LibraryRepository { get; }
        Task CreateTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
        Task SaveAsync();
    }
}
