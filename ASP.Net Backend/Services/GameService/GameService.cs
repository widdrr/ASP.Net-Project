using ASP.Net_Backend.Models;
using ASP.Net_Backend.Repositories;

namespace ASP.Net_Backend.Services.GameService
{
    public class GameService : IGameService
    {
        private IGameRepository _gameRepository;
        
        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        public async Task<Game?> GetByIdAsync(Guid id)
        {
            return await _gameRepository.GetByIdAsync(id);
        }
        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            return await _gameRepository.GetAllAsync();
        }
    }
}
