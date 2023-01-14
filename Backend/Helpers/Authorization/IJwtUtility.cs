using Backend.Models;

namespace Backend.Helpers.Authorization
{
    public interface IJwtUtility
    {
        public string GenerateToken(User user);
        public Guid ValidateToken(string token);
    }
}
