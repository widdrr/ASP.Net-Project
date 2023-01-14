using Backend.Enums;
using Backend.Models.DTOs.Users;
using Backend.Services.UserService;
using AutoMapper;
using Lab4_13.Helpers.Attributes;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            
            if (!users.Any())
                return NotFound();
            

            var userDtos = users.Select(user => new UserResponseDto(user)).ToList();
            return Ok(userDtos);

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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            var userDto = new UserResponseDto(user);
            return Ok(userDto);
        }
        
        [HttpPost("add")]
        [RoleAuthorization(Role.Admin)]
        public async Task<IActionResult> AddUser(UserRequestDto user)
        {
            return Ok(await _userService.CreateAsync(user));
        }

        [HttpPost("admin/add")]
        [RoleAuthorization(Role.Admin)]
        public async Task<IActionResult> AddAdmin(UserRequestDto user)
        {
            return Ok(await _userService.CreateAdminAsync(user));
        }

        [HttpDelete("")]
        [RoleAuthorization(Role.Admin)]
        public async Task<IActionResult> RemoveAll()
        {
            await _userService.DeleteAllAsync();
            return Ok();
        }
        
        [HttpDelete("{id}")]
        [RoleAuthorization(Role.Admin)]
        public async Task<IActionResult> RemoveUser(Guid id)
        {
            await _userService.DeleteByIdAsync(id);
            return Ok();
        }
        
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(UserAuthRequestDto user)
        {
            var token = await _userService.AuthenticateAsync(user);
            if (token == null)
            {
                return BadRequest("Username or password is invalid!");
            }
            return Ok(token);
        }
    }
}
