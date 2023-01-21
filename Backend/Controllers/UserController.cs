using Backend.Enums;
using Backend.Models.DTOs.Users;
using Backend.Services.UserService;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Backend.Helpers.Attributes;

namespace Backend.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetById(Guid userId)
        {
            var user = await _userService.GetByIdAsync(userId);

            if (user == null)
                return NotFound();

            var userDto = _mapper.Map<UserResponseDto>(user);
            return Ok(userDto);
        }

        [HttpPut("{userId}")]
        [OwnerAuthorization]
        public async Task<IActionResult> UpdateUser(Guid userId, UserRequestDto user)
        {
            var newUser = await _userService.UpdateAsync(userId, user);
            if (newUser == null)
                return BadRequest("Invalid values");

            var userDto = _mapper.Map<UserResponseDto>(newUser);
            return Ok(userDto);
        }

        [HttpDelete("{userId}")]
        [RoleAuthorization(Role.Admin)]
        public async Task<IActionResult> RemoveUser(Guid userId)
        {
            await _userService.DeleteByIdAsync(userId);
            return Ok();
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();

            if (!users.Any())
                return NotFound();


            var userDtos = users.Select(user => _mapper.Map<UserResponseDto>(user)).ToList();
            return Ok(userDtos);

        }

        [HttpDelete("")]
        [RoleAuthorization(Role.Admin)]
        public async Task<IActionResult> RemoveAll()
        {
            await _userService.DeleteAllAsync();
            return Ok();
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(UserAuthRequestDto user)
        {
            var response = await _userService.AuthenticateAsync(user);
            if (response == null)
            {
                return BadRequest("Username or password is invalid!");
            }
            return Ok(response);
        }

        [HttpGet("admin")]
        [RoleAuthorization(Role.Admin)]
        public async Task<IActionResult> GetAllAdmin()
        {
            var users = await _userService.GetAllAdminAsync();

            if (!users.Any())
                return NotFound();


            var userDtos = users.Select(user => _mapper.Map<UserResponseDto>(user)).ToList();
            return Ok(userDtos);

        }

        [HttpGet("{userId}/balance")]
        [OwnerAuthorization]
        public async Task<IActionResult> GetAccountBalance(Guid id)
        {
            return Ok(await _userService.GetAccountBalanceAsync(id));
        }
        
    }
}
