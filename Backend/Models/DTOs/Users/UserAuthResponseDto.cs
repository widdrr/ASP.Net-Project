using Backend.Enums;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models.DTOs.Users
{
    public class UserAuthResponseDto
    {
        [StringLength(64)]
        public string Username { get; set; } = null!;
        [StringLength(64)]
        public string Email { get; set; } = null!;
        public DateTime JoinDate { get; set; }
        public double Balance { get; set; }
        public bool Admin { get; set; }
        public Guid Id { get; set; }
        [StringLength(64)]
        public string Token { get; set; }

        public UserAuthResponseDto(User user, double balance, string token)
        {
            Username = user.Username;
            Email = user.Email;
            JoinDate = user.JoinDate;
            Balance = balance;
            Admin = user.Role == Role.Admin;
            Id = user.Id;
            Token = token;
        }
    }

}
