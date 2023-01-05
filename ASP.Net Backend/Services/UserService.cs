using ASP.Net_Backend.Data;
using ASP.Net_Backend.Helpers.Authorization;
using ASP.Net_Backend.Models;
using ASP.Net_Backend.Models.DTOs.Users;
using ASP.Net_Backend.Repositories;
using AutoMapper;
using BCryptNet = BCrypt.Net.BCrypt;

namespace ASP.Net_Backend.Services
{
    public class UserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IJwtUtility _jwtUtility;

        public UserService(IUnitOfWork unitOfWOrk, IMapper mapper, IJwtUtility jwtUtility)
        {
            _unitOfWork = unitOfWOrk;
            _userRepository = _unitOfWork.UserRepository;
            _mapper = mapper;
            _jwtUtility = jwtUtility;
        }
        public async Task<UserResponseDto?> GetByIdAsync(Guid id)
        {
            var userDto = _mapper.Map<UserResponseDto>(await _userRepository.GetByIdAsync(id));
            return userDto;
        }
        public async Task<IEnumerable<UserResponseDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            IEnumerable<UserResponseDto> usersDtos = users.Select(user => _mapper.Map<UserResponseDto>(user));
            return usersDtos;
        }
        public async Task<User?> CreateUserAsync(UserRequestDto user)
        {
            var newUser = new User(user);
            var existingUser = await _userRepository.GetByUsernameAsync(newUser.Username);
            if (existingUser != null)
            {
                return null;
            }
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
        public async Task<string?> Authenticate(UserRequestDto user)
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
