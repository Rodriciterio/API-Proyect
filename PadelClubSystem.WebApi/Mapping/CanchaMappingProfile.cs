using AutoMapper;
using PadelClubSystem.Application.Dtos.Cancha;
using PadelClubSystem.Entities;

namespace PadelClubSystem.WebApi.Mapping
{
    public class CanchaMappingProfile : Profile
    {
        public CanchaMappingProfile()
        {
            CreateMap<Cancha, CanchaResponseDto>().
               ForMember(dest => dest.Nombre, ori => ori.MapFrom(src => src.Nombre.ToLower()));
            CreateMap<CanchaRequestDto, Cancha>();
        }
    }
}
