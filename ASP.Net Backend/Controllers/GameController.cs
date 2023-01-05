using ASP.Net_Backend.Enums;
using ASP.Net_Backend.Models;
using ASP.Net_Backend.Models.DTOs.Games;
using ASP.Net_Backend.Services;
using Lab4_13.Helpers.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Net_Backend.Controllers
{
    [Route("api/game")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _gameService.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var game = _gameService.GetByIdAsync(id);

            if (await game == null)
                return NotFound();
            return Ok(await game);
        }
        [HttpPost("add")]
        [RoleAuthorization(Role.Admin)]
        public async Task<IActionResult> AddGame(GameRequestDto game)
        {
            return Ok(await _gameService.CreateAsync(game));
        }
        [HttpDelete("")]
        [RoleAuthorization(Role.Admin)]
        public async Task<IActionResult> RemoveAll()
        {
            await _gameService.DeleteAllAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        [RoleAuthorization(Role.Admin)]
        public async Task<IActionResult> RemoveGame(Guid id)
        {
            await _gameService.DeleteByIdAsync(id);
            return Ok();
        }
    }
}
