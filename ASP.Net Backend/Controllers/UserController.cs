using ASP.Net_Backend.Enums;
using ASP.Net_Backend.Models.DTOs.Users;
using ASP.Net_Backend.Services;
using AutoMapper;
using Lab4_13.Helpers.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Net_Backend.Controllers
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
        public async Task<IActionResult> Authenticate(UserRequestDto user)
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
