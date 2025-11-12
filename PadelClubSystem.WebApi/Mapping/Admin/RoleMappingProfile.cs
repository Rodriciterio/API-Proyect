using AutoMapper;
using PadelClubSystem.Application.Dtos.Identity.Roles;
using PadelClubSystem.Entities.MicrosoftIdentity;

namespace PadelClubSystem.WebApi.Mapping
{
    public class RoleMappingProfile : Profile
    {
        public RoleMappingProfile()
        {
            CreateMap<Role, RoleResponseDto>();
            CreateMap<RoleRequestDto, Role>();
        }
    }
}
