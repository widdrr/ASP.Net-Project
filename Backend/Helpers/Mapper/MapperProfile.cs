using Backend.Models;
using Backend.Models.DTOs.Games;
using Backend.Models.DTOs.Users;
using AutoMapper;
using Backend.Enums;

namespace Backend.Helpers.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<GameRequestDto, Game>()
                .ForMember(dest => dest.Id,
                    opts => opts.NullSubstitute(Guid.NewGuid()));

            CreateMap<Game, GameResponseDto>();

            CreateMap<User, UserResponseDto>();
        }
    }
}
