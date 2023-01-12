using ASP.Net_Backend.Data;
using ASP.Net_Backend.Enums;
using ASP.Net_Backend.Models;
using ASP.Net_Backend.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace ASP.Net_Backend.Repositories.UserRepository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(GameStoreContext gameStoreContext) : base(gameStoreContext)
        { }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _table.FirstOrDefaultAsync(u => u.Username == username);
        }
        public async Task<User?> GetByIdWithLibraryAsync(Guid id)
        {
            return await _table.Include(u => u.Library).FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<IEnumerable<User>> GetAllWithLibrariesAsync()
        {
            return await _table.Include(u => u.Library).ToListAsync();
        }
        public async Task<IEnumerable<User>> GetAllAdminWithLibrariesAsync()
        {
            return await _table.Where(u => u.Role == Role.Admin).Include(u => u.Library).ToListAsync();
        }

    }
}
