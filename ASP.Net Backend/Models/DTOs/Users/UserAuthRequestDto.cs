using System.ComponentModel.DataAnnotations;

namespace ASP.Net_Backend.Models.DTOs.Users
{
    public class UserAuthRequestDto
    {
        [StringLength(64)]
        public string Username { get; set; } = null!;
        [StringLength(64)]
        public string Password { get; set; } = null!;
    }
}
