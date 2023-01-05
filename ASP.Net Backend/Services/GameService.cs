using ASP.Net_Backend.Data;
using ASP.Net_Backend.Models;
using ASP.Net_Backend.Models.DTOs.Games;
using ASP.Net_Backend.Repositories;
using AutoMapper;

namespace ASP.Net_Backend.Services
{
    public class GameService : IGameService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public GameService(IUnitOfWork unitOfWOrk, IMapper mapper)
        {
            _unitOfWork = unitOfWOrk;
            _gameRepository = _unitOfWork.GameRepository;
            _mapper = mapper;
        }
        public async Task<GameResponseDto?> GetByIdAsync(Guid id)
        {
            var gameDto = _mapper.Map<GameResponseDto>(await _gameRepository.GetByIdAsync(id));
            return gameDto;
        }
        public async Task<IEnumerable<GameResponseDto>> GetAllAsync()
        {
            var games = await _gameRepository.GetAllAsync();
            IEnumerable<GameResponseDto> gameDtos = games.Select(game => _mapper.Map<GameResponseDto>(game));
            return gameDtos;
        }
        public async Task<Game?> CreateAsync(GameRequestDto game)
        {
            var newGame = _mapper.Map<Game>(game);
            var existingGame = await _gameRepository.GetByNameAsync(newGame.Name);
            if (existingGame != null)
            {
                return null;
            }
            await _gameRepository.CreateAsync(newGame);
            await _unitOfWork.SaveAsync();
            return newGame;
        }
        public async Task DeleteByIdAsync(Guid id)
        {
            var game = await _gameRepository.GetByIdAsync(id);
            if (game == null)
                return;
            _gameRepository.Delete(game);
            await _unitOfWork.SaveAsync();
        }
        public async Task DeleteAllAsync()
        {
            var allGames = _gameRepository.GetAllAsync();
            _gameRepository.DeleteRange(await allGames);
            await _unitOfWork.SaveAsync();
        }

    }
}
