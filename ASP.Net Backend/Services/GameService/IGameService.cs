using ASP.Net_Backend.Models;
using ASP.Net_Backend.Models.DTOs.Games;

namespace ASP.Net_Backend.Services.GameService
{
    public interface IGameService
    {
        Task<Game?> GetByIdAsync(Guid id);
        Task<IEnumerable<Game>> GetAllAsync();
        Task<Game?> CreateAsync(GameRequestDto game);
        Task DeleteByIdAsync(Guid id);
        Task DeleteAllAsync();
    }
}
