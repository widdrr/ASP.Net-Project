using ASP.Net_Backend.Enums;
using ASP.Net_Backend.Models;
using ASP.Net_Backend.Models.DTOs.Games;
using ASP.Net_Backend.Services;
using AutoMapper;
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
        private IMapper _mapper;
        public GameController(IGameService gameService, IMapper mapper)
        {
            _gameService = gameService;
            _mapper = mapper;

        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var games = await _gameService.GetAllAsync();
            if(!games.Any())
                return NotFound();
            var gameDtos = games.Select(game => _mapper.Map<GameResponseDto>(game));
            return Ok(gameDtos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var game = _gameService.GetByIdAsync(id);

            if (await game == null)
                return NotFound();

            var gameDto = _mapper.Map<GameResponseDto>(game);
            return Ok(gameDto);
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
