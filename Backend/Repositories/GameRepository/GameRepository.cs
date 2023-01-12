using Backend.Data;
using Backend.Models;
using Backend.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories.GameRepository
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(GameStoreContext gameStoreContext) : base(gameStoreContext)
        { }

        public async Task<Game?> GetByNameAsync(string name)
        {
            return await _table.FirstOrDefaultAsync(g => g.Name == name);

        }
    }
}
