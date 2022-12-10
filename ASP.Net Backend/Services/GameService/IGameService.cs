using ASP.Net_Backend.Models;

namespace ASP.Net_Backend.Services.GameService
{
    public interface IGameService
    {
        Task<Game?> GetByIdAsync(Guid id);
        Task<IEnumerable<Game>> GetAllAsync();
    }
}
