using ASP.Net_Backend.Models;

namespace ASP.Net_Backend.Helpers.Authorization
{
    public interface IJwtUtility
    {
        public string GenerateToken(User user);
        public Guid ValidateToken(string token);
    }
}
