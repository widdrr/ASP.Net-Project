using ASP.Net_Backend.Data;
using ASP.Net_Backend.Models;
using ASP.Net_Backend.Repositories.BaseRepository;

namespace ASP.Net_Backend.Repositories
{
    public class GameRepository : BaseRepository<Game>, IGameRepository 
    {
        public GameRepository(GameStoreContext gameStoreContext) : base(gameStoreContext)
        {}
    }
}
