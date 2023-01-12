using ASP.Net_Backend.Models;
using ASP.Net_Backend.Models.DTOs.Games;
using ASP.Net_Backend.Models.DTOs.Users;
using AutoMapper;

namespace ASP.Net_Backend.Helpers.Mapper
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
