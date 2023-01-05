using ASP.Net_Backend.Models;
using ASP.Net_Backend.Models.DTOs.Games;

namespace ASP.Net_Backend.Services
{
    public interface IGameService
    {
        Task<GameResponseDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<GameResponseDto>> GetAllAsync();
        Task<Game?> CreateAsync(GameRequestDto game);
        Task DeleteByIdAsync(Guid id);
        Task DeleteAllAsync();
    }
}
