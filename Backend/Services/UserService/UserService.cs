using Backend.Data;
using Backend.Enums;
using Backend.Helpers.Authorization;
using Backend.Models;
using Backend.Models.DTOs.Users;
using Backend.Repositories.TransactionRepository;
using Backend.Repositories.UserRepository;
using AutoMapper;
using BCryptNet = BCrypt.Net.BCrypt;
using Backend.Models.DTOs.Games;

namespace Backend.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IJwtUtility _jwtUtility;

        public UserService(IUnitOfWork unitOfWOrk, IJwtUtility jwtUtility)
        {
            _unitOfWork = unitOfWOrk;
            _userRepository = _unitOfWork.UserRepository;
            _transactionRepository = _unitOfWork.TransactionRepository;
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
            var newUser = new User(user);
            await _userRepository.CreateAsync(newUser);
            try
            {
                await _unitOfWork.SaveAsync();
            }
            catch (Exception)
            {
                return null;
            }
            return newUser;
        }

        public async Task<User?> UpdateAsync(Guid id, UserRequestDto user)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);

            if (existingUser == null)
            {
                existingUser = new User(user);
                await _userRepository.CreateAsync(existingUser);

            }
            else
            {
                existingUser.Username = user.Username;
                existingUser.Email = user.Email;
                existingUser.PasswordHash = BCryptNet.HashPassword(user.Password);
            }

            try
            {
                await _unitOfWork.SaveAsync();
            }
            catch (Exception)
            {
                return null;
            }
            return existingUser;
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
        public Task<int> GetAccountBalance(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
