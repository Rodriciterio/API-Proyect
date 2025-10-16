using AutoMapper;
using PadelClubSystem.Application.Dtos.Socio;
using PadelClubSystem.Entities;

namespace PadelClubSystem.WebApi.Mapping
{
    public class SocioMappingProfile : Profile
    {
        public SocioMappingProfile()
        {
            CreateMap<Socio, SocioResponseDto>().
               ForMember(dest => dest.FechaAlta, ori => ori.MapFrom(src => src.FechaAlta.ToShortDateString()));
            CreateMap<SocioRequestDto, Socio>();
        }
    }
}
