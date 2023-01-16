using Backend.Enums;
using Backend.Models.DTOs.Users;
using Backend.Services.UserService;
using AutoMapper;
using Lab4_13.Helpers.Attributes;
using Microsoft.AspNetCore.Mvc;
using Backend.Helpers.Attributes;

namespace Backend.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            var userDto = new UserResponseDto(user);
            return Ok(userDto);
        }
        
        [HttpPut("{id}")]
        [OwnerAuthorization]
        public async Task<IActionResult> UpdateUser(Guid id,UserRequestDto user)
        {
            var newUser = await _userService.UpdateAsync(id,user);
            if (newUser == null)
                return BadRequest("Invalid values");

            var userDto = new UserResponseDto(newUser);
            return Ok(userDto);
        }

        [HttpDelete("{id}")]
        [RoleAuthorization(Role.Admin)]
        public async Task<IActionResult> RemoveUser(Guid id)
        {
            await _userService.DeleteByIdAsync(id);
            return Ok();
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();

            if (!users.Any())
                return NotFound();


            var userDtos = users.Select(user => new UserResponseDto(user)).ToList();
            return Ok(userDtos);

        }

        [HttpDelete("")]
        [RoleAuthorization(Role.Admin)]
        public async Task<IActionResult> RemoveAll()
        {
            await _userService.DeleteAllAsync();
            return Ok();
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddUser(UserRequestDto user)
        {
            var newUser = await _userService.CreateAsync(user);
            if (newUser == null)
                return BadRequest("Invalid Values");

            var userDto = new UserResponseDto(newUser);
            return Ok(userDto);

        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(UserAuthRequestDto user)
        {
            var token = await _userService.AuthenticateAsync(user);
            if (token == null)
            {
                return BadRequest("Username or password is invalid!");
            }
            return Ok(new { token });
        }

        [HttpGet("admin")]
        [RoleAuthorization(Role.Admin)]
        public async Task<IActionResult> GetAllAdmin()
        {
            var users = await _userService.GetAllAdminAsync();

            if (!users.Any())
                return NotFound();


            var userDtos = users.Select(user => new UserResponseDto(user)).ToList();
            return Ok(userDtos);

        }
        
    }
}
