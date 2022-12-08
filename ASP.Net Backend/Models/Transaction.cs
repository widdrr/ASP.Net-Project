﻿using ASP.Net_Backend.Models.Associations;
using ASP.Net_Backend.Models.Base;

namespace ASP.Net_Backend.Models
{
    public class Transaction : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public DateTime Date { get; set; }
        public Purchase? Purchase { get; set; }
        public Deposit? Deposit { get; set; }
    }
}