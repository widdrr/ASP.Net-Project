using Backend.Models;
using Backend.Repositories.BaseRepository;

namespace Backend.Repositories.GameRepository
{
    public interface IGameRepository : IBaseRepository<Game>
    {
        Task<Game?> GetByNameAsync(string name);
    }
}
