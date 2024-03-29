﻿using Backend.Data;
using Backend.Models;
using Backend.Models.DTOs.Games;
using Backend.Repositories.GameRepository;
using AutoMapper;

namespace Backend.Services.GameService
{
    public class GameService : IGameService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public GameService(IUnitOfWork unitOfWOrk, IMapper mapper)
        {
            _unitOfWork = unitOfWOrk;
            _gameRepository = _unitOfWork.GameRepository;
            _mapper = mapper;
        }
        public async Task<Game?> GetByIdAsync(Guid id)
        {
            return await _gameRepository.GetByIdAsync(id);
        }
        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            return await _gameRepository.GetAllAsync();
        }
        public async Task<IEnumerable<Game>> GetByIdRangeAsync(IEnumerable<Guid> ids)
        {
            return await _gameRepository.GetByIdRangeAsync(ids);
        }
        public async Task<Game?> CreateAsync(GameRequestDto game)
        {
            var newGame = _mapper.Map<Game>(game);
            await _gameRepository.CreateAsync(newGame);
            try
            {
                await _unitOfWork.SaveAsync();
            }
            catch(Exception)
            {
                return null;
            }
            return newGame;
        }

        public async Task<Game?> UpdateAsync(Guid id, GameRequestDto game)
        {
            var existingGame = await _gameRepository.GetByIdAsync(id);

            if (existingGame == null)
            {
                existingGame = _mapper.Map<Game>(game);
                await _gameRepository.CreateAsync(existingGame);

            }
            else
            {
                existingGame.Name = game.Name;
                existingGame.Developer = game.Developer;
                existingGame.Price = game.Price;
                existingGame.Developer = game.Developer;
            }

            try
            {
                await _unitOfWork.SaveAsync();
            }
            catch (Exception)
            {
                return null;
            }
            return existingGame;
        }
        public async Task DeleteByIdAsync(Guid id)
        {
            var game = await _gameRepository.GetByIdAsync(id);
            if (game == null)
                return;
            _gameRepository.Delete(game);
            await _unitOfWork.SaveAsync();
        }
        public async Task DeleteAllAsync()
        {
            var allGames = _gameRepository.GetAllAsync();
            _gameRepository.DeleteRange(await allGames);
            await _unitOfWork.SaveAsync();
        }

    }
}
