using ASP.Net_Backend.Enums;
using System.ComponentModel.DataAnnotations;

namespace ASP.Net_Backend.Models.DTOs.Users
{
    public class UserResponseDto
    {

        [StringLength(64)]
        public string Username { get; set; } = null!;
        [StringLength(64)]
        public string Email { get; set; } = null!;
        public Role Role { get; set; }
        public DateTime JoinDate { get; set; }
        public bool HasLibrary { get; set; }

        public UserResponseDto(User user)
        {
            Username = user.Username;
            Email = user.Email;
            Role = user.Role;
            JoinDate = user.JoinDate;
            HasLibrary = user.Library != null;
        }
    }
   
}
