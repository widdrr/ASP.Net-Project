using System.ComponentModel.DataAnnotations;

namespace Backend.Models.DTOs.Users
{
    public class UserRequestDto
    {
        [StringLength(64)]
        public string Username { get; set; } = null!;
        [StringLength(64)]
        public string Email { get; set; } = null!;
        [StringLength(64)]
        public string Password { get; set; } = null!;
    }
}
