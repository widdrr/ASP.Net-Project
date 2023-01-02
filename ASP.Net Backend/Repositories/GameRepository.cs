using ASP.Net_Backend.Data;
using ASP.Net_Backend.Models;
using ASP.Net_Backend.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace ASP.Net_Backend.Repositories
{
    public class GameRepository : BaseRepository<Game>, IGameRepository 
    {
        public GameRepository(GameStoreContext gameStoreContext) : base(gameStoreContext)
        {}

        public async Task<Game?> GetByNameAsync(String name)
        {
            return await _table.FirstOrDefaultAsync(g => g.Name == name);

        }
    }
}
