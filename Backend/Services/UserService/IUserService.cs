using Backend.Models;
using Backend.Models.DTOs.Users;

namespace Backend.Services.UserService
{
    public interface IUserService
    {
        Task<User?> GetByIdAsync(Guid id);
        Task<IEnumerable<User>> GetAllAsync();
        Task<IEnumerable<User>> GetAllAdminAsync();
        Task<User?> CreateAsync(UserRequestDto userReq);
        Task<User?> UpdateAsync(Guid id,UserRequestDto userReq);
        Task DeleteByIdAsync(Guid id);
        Task DeleteAllAsync();
        Task<string?> AuthenticateAsync(UserAuthRequestDto userReq);
        Task<int> GetAccountBalance(Guid userId);
    }
}
