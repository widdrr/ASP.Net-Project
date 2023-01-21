using Backend.Data;
using Backend.Models;
using Backend.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories.LibraryRepository
{
    public class LibraryRepository : BaseRepository<Library>, ILibraryRepository
    {
        public LibraryRepository(GameStoreContext gameStoreContext) : base(gameStoreContext)
        { }

        public async Task<Library?> GetLibraryByOwnerAsync(Guid userId)
        {
            return await _table
                         .Where(l => l.UserId == userId)
                         .Include(l => l.Games)
                         .FirstOrDefaultAsync();
        }
    }
}
