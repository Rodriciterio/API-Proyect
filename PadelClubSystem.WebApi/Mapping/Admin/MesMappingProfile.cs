using AutoMapper;
using PadelClubSystem.Application.Dtos.Admin.Mes;
using PadelClubSystem.Entities;

namespace PadelClubSystem.WebApi.Mapping.Admin
{
    public class MesMappingProfile : Profile
    {
        public MesMappingProfile()
        {
            CreateMap<Mes, MesResponseDto>();
            CreateMap<MesRequestDto, Mes>().ConstructUsing(dto => new Mes(dto.Nombre)); ;
        }
    }
}
