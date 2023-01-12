using ASP.Net_Backend.Models;
using ASP.Net_Backend.Repositories.BaseRepository;

namespace ASP.Net_Backend.Repositories.GameRepository
{
    public interface IGameRepository : IBaseRepository<Game>
    {
        Task<Game?> GetByNameAsync(string name);
    }
}
