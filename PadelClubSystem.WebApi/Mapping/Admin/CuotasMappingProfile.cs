using AutoMapper;
using PadelClubSystem.Application.Dtos.Admin.Cuota;
using PadelClubSystem.Entities;

namespace PadelClubSystem.WebApi.Mapping.Admin
{
    public class CuotasMappingProfile : Profile
    {
        public CuotasMappingProfile()
        {
            CreateMap<Cuota, CuotaResponseDto>().
                ForMember(dest => dest.CaducaEn, ori => ori.MapFrom(src => src.CaducaEn.ToShortDateString())).
                ForMember(dest => dest.Mes, ori => ori.MapFrom(src => src.Mes.Nombre)).
                ForMember(dest => dest.Anio, ori => ori.MapFrom(src => src.Anio.Numero.ToString()));
            CreateMap<CuotaRequestDto, Cuota>();
        }
    }
}
