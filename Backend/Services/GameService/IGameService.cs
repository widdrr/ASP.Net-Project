using Backend.Models;
using Backend.Models.DTOs.Games;

namespace Backend.Services.GameService
{
    public interface IGameService
    {
        Task<Game?> GetByIdAsync(Guid id);
        Task<IEnumerable<Game>> GetAllAsync();
        Task<IEnumerable<Game>> GetByIdRangeAsync(IEnumerable<Guid> ids);
        Task<Game?> CreateAsync(GameRequestDto game);
        Task<Game?> UpdateAsync(Guid id, GameRequestDto game);
        Task DeleteByIdAsync(Guid id);
        Task DeleteAllAsync();
    }
}
