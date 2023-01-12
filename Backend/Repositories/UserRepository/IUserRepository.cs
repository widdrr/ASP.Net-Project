using ASP.Net_Backend.Models;
using ASP.Net_Backend.Repositories.BaseRepository;

namespace ASP.Net_Backend.Repositories.UserRepository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<User?> GetByIdWithLibraryAsync(Guid id);
        Task<IEnumerable<User>> GetAllWithLibrariesAsync();
        Task<IEnumerable<User>> GetAllAdminWithLibrariesAsync();
    }
}
