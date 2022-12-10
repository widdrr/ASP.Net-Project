using ASP.Net_Backend.Models;
using ASP.Net_Backend.Services.GameService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Net_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _gameService.GetAllAsync());
        }
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var game = _gameService.GetByIdAsync(id);

            if (await game == null)
                return NotFound();
            return Ok(await game);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddGame(Game game)
        {

        }
    }
}
