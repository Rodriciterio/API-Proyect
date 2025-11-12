using AutoMapper;
using PadelClubSystem.Application.Dtos.Admin.Anio;
using PadelClubSystem.Entities;

namespace PadelClubSystem.WebApi.Mapping.Admin
{
    public class AnioMappingProfile : Profile
    {
        public AnioMappingProfile()
        {
            CreateMap<Anio, AnioResponseDto>();
            CreateMap<AnioRequestDto, Anio>().ConstructUsing(dto => new Anio(dto.Numero));
        }
    }
}
