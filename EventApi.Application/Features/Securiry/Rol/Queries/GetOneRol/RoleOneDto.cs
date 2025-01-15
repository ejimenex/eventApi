using EventApi.Application.Features.Securiry.Rol.Queries.GetAllRole;
using EventApi.Application.Features.Securiry.RolePermissions.Queries.GetByRol;
using EventApi.Domain.Entities.Security;

namespace EventApi.Application.Features.Securiry.Rol.Queries.GetOneRol
{
    public class RoleOneDto:RoleDto
    {
        public List<RolPermissionDto> RolPermission { get; set; }
    }
}
