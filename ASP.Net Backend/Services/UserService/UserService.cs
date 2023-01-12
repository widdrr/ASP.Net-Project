using ASP.Net_Backend.Data;
using ASP.Net_Backend.Enums;
using ASP.Net_Backend.Helpers.Authorization;
using ASP.Net_Backend.Models;
using ASP.Net_Backend.Models.DTOs.Users;
using ASP.Net_Backend.Repositories.UserRepository;
using AutoMapper;
using BCryptNet = BCrypt.Net.BCrypt;

namespace ASP.Net_Backend.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IJwtUtility _jwtUtility;

        public UserService(IUnitOfWork unitOfWOrk, IJwtUtility jwtUtility)
        {
            _unitOfWork = unitOfWOrk;
            _userRepository = _unitOfWork.UserRepository;
            _jwtUtility = jwtUtility;
        }
        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _userRepository.GetByIdWithLibraryAsync(id);
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllWithLibrariesAsync();
        }

        public async Task<IEnumerable<User>> GetAllAdminAsync()
        {
            return await _userRepository.GetAllAdminWithLibrariesAsync();
        }
        public async Task<User?> CreateAsync(UserRequestDto user)
        {
            var existingUser = await _userRepository.GetByUsernameAsync(user.Username);
            if (existingUser != null)
            {
                return null;
            }

            var newUser = new User(user);
            await _userRepository.CreateAsync(newUser);
            await _unitOfWork.SaveAsync();
            return newUser;
        }
        public async Task<User?> CreateAdminAsync(UserRequestDto user)
        {
            var existingUser = await _userRepository.GetByUsernameAsync(user.Username);
            if (existingUser != null)
            {
                return null;
            }

            var newUser = new User(user);
            newUser.Role = Role.Admin;
            await _userRepository.CreateAsync(newUser);
            await _unitOfWork.SaveAsync();
            return newUser;
        }
        public async Task DeleteByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return;
            _userRepository.Delete(user);
            await _unitOfWork.SaveAsync();
        }
        public async Task DeleteAllAsync()
        {
            var allusers = _userRepository.GetAllAsync();
            _userRepository.DeleteRange(await allusers);
            await _unitOfWork.SaveAsync();
        }
        public async Task<string?> AuthenticateAsync(UserAuthRequestDto user)
        {
            var existingUser = await _userRepository.GetByUsernameAsync(user.Username);
            if (existingUser == null || !BCryptNet.Verify(user.Password, existingUser.PasswordHash))
            {
                return null;
            }
            var jwtToken = _jwtUtility.GenerateToken(existingUser);
            return jwtToken;
        }

    }
}
