using Backend.Models;
using Backend.Repositories.BaseRepository;

namespace Backend.Repositories.UserRepository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<User?> GetByUsernameWithLibraryAsync(string username);
        Task<User?> GetByIdWithLibraryAsync(Guid id);
        Task<IEnumerable<User>> GetAllWithLibrariesAsync();
        Task<IEnumerable<User>> GetAllAdminWithLibrariesAsync();
    }
}
