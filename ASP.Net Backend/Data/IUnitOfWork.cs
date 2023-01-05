using ASP.Net_Backend.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ASP.Net_Backend.Data
{
    public interface IUnitOfWork
    {
        GameStoreContext Context { get; }
        IGameRepository GameRepository { get; }
        IUserRepository UserRepository { get; }
        Task CreateTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
        Task SaveAsync();
    }
}
