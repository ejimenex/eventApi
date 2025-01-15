using AutoMapper;
using EventApi.Application.Features.Securiry.Rol.Command.CreateRol;
using EventApi.Application.Features.Securiry.Rol.Queries.GetAllRole;
using EventApi.Application.Features.Securiry.RolePermissions.Queries.GetByRol;
using EventApi.Domain.Entities.Security;

namespace EventApi.Application.Profiles
{
    public class RoleProfile: Profile
    {
        public RoleProfile()
    {
            CreateMap<CreateRolCommand, Role>().ReverseMap();

            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<RolPermission, RolPermissionDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
        }
     
    }
}
