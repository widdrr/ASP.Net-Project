using Backend.Models;
using Backend.Repositories.BaseRepository;

namespace Backend.Repositories.LibraryRepository
{
    public interface ILibraryRepository : IBaseRepository<Library>
    {
        Task<Library?> GetLibraryByOwnerAsync(Guid userId);
    }
}
