using AutoMapper;
using PadelClubSystem.Application.Dtos.Socio;
using PadelClubSystem.Application.Dtos.Torneo;
using PadelClubSystem.Entities;

namespace PadelClubSystem.WebApi.Mapping
{
    public class TorneoMappingProfile : Profile
    {
        public TorneoMappingProfile()
        {
            CreateMap<Torneo, TorneoResponseDto>().
                ForMember(dest => dest.Nombre, ori => ori.MapFrom(src => src.Nombre.ToLower()));
            CreateMap<TorneoRequestDto, Torneo>();
        }
    }
}
