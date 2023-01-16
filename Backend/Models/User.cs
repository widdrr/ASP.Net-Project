using Backend.Enums;
using Backend.Models.Base;
using Backend.Models.DTOs.Users;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Backend.Models
{
    [Index(nameof(Username), IsUnique = true)]
    public class User : BaseEntity
    {
        [StringLength(64)]
        public string Username { get; set; } = null!;
        [StringLength(64)]
        public string Email { get; set; } = null!;
        [JsonIgnore]
        public string PasswordHash { get; set; } = null!;
        public Role Role { get; set; }
        public DateTime JoinDate { get; set; }
        public Library? Library { get; set; }
        public ICollection<Transaction>? Transactions { get; set; }

        public User(){}
        public User(UserRequestDto userReq)
        {
            Username = userReq.Username;
            Email = userReq.Email;
            PasswordHash = BCryptNet.HashPassword(userReq.Password);
            JoinDate = DateTime.Now;
        }
    }
}
