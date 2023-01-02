using ASP.Net_Backend.Models;
using ASP.Net_Backend.Repositories.BaseRepository;

namespace ASP.Net_Backend.Repositories
{
    public interface IGameRepository : IBaseRepository<Game>
    {
        Task<Game?> GetByNameAsync(String name);
    }
}
