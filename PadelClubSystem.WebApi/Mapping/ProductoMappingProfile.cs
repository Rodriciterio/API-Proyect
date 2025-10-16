using AutoMapper;
using PadelClubSystem.Application.Dtos.Producto;
using PadelClubSystem.Entities;

namespace PadelClubSystem.WebApi.Mapping
{
    public class ProductoMappingProfile : Profile
    {
        public ProductoMappingProfile()
        {
            CreateMap<Producto, ProductoResponseDto>().
               ForMember(dest => dest.Nombre, ori => ori.MapFrom(src => src.Nombre.ToLower()));
            CreateMap<ProductoRequestDto, Producto>();
        }
    }
}
