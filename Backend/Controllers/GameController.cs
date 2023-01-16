using Backend.Enums;
using Backend.Models;
using Backend.Models.DTOs.Games;
using Backend.Services.GameService;
using AutoMapper;
using Lab4_13.Helpers.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var game = _gameService.GetByIdAsync(id);

            if (await game == null)
                return NotFound();

            var gameDto = _mapper.Map<GameResponseDto>(game);
            return Ok(gameDto);
        }

        [HttpPut("{id}")]
        [RoleAuthorization(Role.Admin)]
        public async Task<IActionResult> UpdateGame(Guid id,GameRequestDto game)
        {
            var newGame = await _gameService.UpdateAsync(id,game);
            if (newGame == null)
                return BadRequest("Invalid values");
            
            var newGameDto = _mapper.Map<GameResponseDto>(newGame);
            return Ok(newGameDto);
        }

        [HttpDelete("{id}")]
        [RoleAuthorization(Role.Admin)]
        public async Task<IActionResult> RemoveGame(Guid id)
        {
            await _gameService.DeleteByIdAsync(id);
            return Ok();
        }

        [HttpPost("add")]
        [RoleAuthorization(Role.Admin)]
        public async Task<IActionResult> AddGame(GameRequestDto game)
        {
            var newGame = await _gameService.CreateAsync(game);
            if (newGame == null)
                return BadRequest("Game already exists");

            var gameDto = _mapper.Map<GameResponseDto>(newGame);
            return Ok(gameDto);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var games = await _gameService.GetAllAsync();
            if (!games.Any())
                return NotFound();

            var gameDtos = games.Select(game => _mapper.Map<GameResponseDto>(game));
            return Ok(gameDtos);
        }

        [HttpDelete("")]
        [RoleAuthorization(Role.Admin)]
        public async Task<IActionResult> RemoveAll()
        {
            await _gameService.DeleteAllAsync();
            return Ok();
        }
    }
}
