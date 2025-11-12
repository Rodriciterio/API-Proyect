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
               ForMember(dest => dest.FechaNacimiento, ori => ori.MapFrom(src => src.FechaNacimiento.ToShortDateString()));
            CreateMap<SocioRequestDto, Socio>().ConstructUsing(dto => new Socio(dto.Nombre, dto.Apellido, dto.Email));
        }
    }
}
