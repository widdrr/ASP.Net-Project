using Backend.Models;
using Backend.Models.DTOs.Games;
using Backend.Models.DTOs.Users;
using AutoMapper;

namespace Backend.Helpers.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<GameRequestDto, Game>()
                .ForMember(dest => dest.Id,
                    opts => opts.NullSubstitute(new Guid()));

            CreateMap<Game, GameResponseDto>();
        }
    }
}
