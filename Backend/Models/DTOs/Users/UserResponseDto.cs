using Backend.Enums;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models.DTOs.Users
{
    public class UserResponseDto
    {

        [StringLength(64)]
        public string Username { get; set; } = null!;
        [StringLength(64)]
        public string Email { get; set; } = null!;
        public DateTime JoinDate { get; set; }
        public bool HasLibrary { get; set; }

        public UserResponseDto(User user)
        {
            Username = user.Username;
            Email = user.Email;
            JoinDate = user.JoinDate;
            HasLibrary = user.Library != null;
        }
    }
   
}
