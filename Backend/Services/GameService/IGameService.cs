﻿using Backend.Models;
using Backend.Models.DTOs.Games;

namespace Backend.Services.GameService
{
    public interface IGameService
    {
        Task<Game?> GetByIdAsync(Guid id);
        Task<IEnumerable<Game>> GetAllAsync();
        Task<Game?> CreateAsync(GameRequestDto game);
        Task DeleteByIdAsync(Guid id);
        Task DeleteAllAsync();
    }
}