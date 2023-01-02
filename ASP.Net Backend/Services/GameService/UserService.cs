namespace ASP.Net_Backend.Services.GameService
{
    public class UserService
    {
        Task<GameResponseDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<GameResponseDto>> GetAllAsync();
        Task<Game?> CreateAsync(GameRequestDto game);
        Task DeleteByIdAsync(Guid id);
        Task DeleteAllAsync();
    }
}
