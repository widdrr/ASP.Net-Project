using Backend.Data;
using Backend.Enums;
using Backend.Models;
using Backend.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories.UserRepository
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
