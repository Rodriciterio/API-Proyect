using AutoMapper;
using PadelClubSystem.Application.Dtos.Pedido;
using PadelClubSystem.Entities;

namespace PadelClubSystem.WebApi.Mapping
{
    public class PedidoMappingProfile : Profile
    {
        public PedidoMappingProfile()
        {
            CreateMap<Pedido, PedidoResponseDto>().
               ForMember(dest => dest.Fecha, ori => ori.MapFrom(src => src.Fecha.ToShortDateString()));
            CreateMap<PedidoRequestDto, Pedido>();
        }
    }
}
