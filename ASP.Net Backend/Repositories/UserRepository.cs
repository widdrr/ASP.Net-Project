using ASP.Net_Backend.Data;
using ASP.Net_Backend.Models;
using ASP.Net_Backend.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace ASP.Net_Backend.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(GameStoreContext gameStoreContext) : base(gameStoreContext)
        { }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _table.FirstOrDefaultAsync(g => g.Username == username);

        }

    }
}
