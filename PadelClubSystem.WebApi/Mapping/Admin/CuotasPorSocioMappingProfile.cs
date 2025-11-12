using AutoMapper;
using PadelClubSystem.Application.Dtos.Admin.CuotaPorSocio;
using PadelClubSystem.Entities;

namespace PadelClubSystem.WebApi.Mapping.Admin
{
    public class CuotasPorSocioMappingProfile : Profile
    {
        public CuotasPorSocioMappingProfile()
        {
            CreateMap<CuotaPorSocio, CuotaPorSocioResponseDto>().
                ForMember(dest => dest.Socio, ori => ori.MapFrom(src => src.Socio.GetCompleteName())).
                ForMember(dest => dest.Couta, ori => ori.MapFrom(src => src.Cuota.GetName()));
            CreateMap<CuotaPorSocioRequestDto, CuotaPorSocio>();
        }
    }
}
