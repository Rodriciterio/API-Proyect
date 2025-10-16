using AutoMapper;
using PadelClubSystem.Application.Dtos.Reserva;
using PadelClubSystem.Entities.Entities;

namespace PadelClubSystem.WebApi.Mapping
{
    public class ReservaMappingProfile : Profile
    {
        public ReservaMappingProfile()
        {
            CreateMap<Reserva, ReservaResponseDto>().
              ForMember(dest => dest.Id, ori => ori.MapFrom(src => src.Id.ToString()));
            CreateMap<ReservaRequestDto, Reserva>();
        }
    }
}
