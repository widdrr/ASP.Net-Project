using ASP.Net_Backend.Models;
using ASP.Net_Backend.Models.DTOs.Users;

namespace ASP.Net_Backend.Services
{
    public interface IUserService
    {
        Task<User?> GetByIdAsync(Guid id);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> CreateAsync(UserRequestDto userReq);
        Task DeleteByIdAsync(Guid id);
        Task DeleteAllAsync();
        Task<string?> AuthenticateAsync(UserRequestDto userReq);
    }
}
