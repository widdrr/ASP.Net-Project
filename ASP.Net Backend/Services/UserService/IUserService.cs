using ASP.Net_Backend.Models;
using ASP.Net_Backend.Models.DTOs.Users;

namespace ASP.Net_Backend.Services.UserService
{
    public interface IUserService
    {
        Task<User?> GetByIdAsync(Guid id);
        Task<IEnumerable<User>> GetAllAsync();
        Task<IEnumerable<User>> GetAllAdminAsync();
        Task<User?> CreateAsync(UserRequestDto userReq);
        Task<User?> CreateAdminAsync(UserRequestDto userReq);
        Task DeleteByIdAsync(Guid id);
        Task DeleteAllAsync();
        Task<string?> AuthenticateAsync(UserAuthRequestDto userReq);
    }
}
