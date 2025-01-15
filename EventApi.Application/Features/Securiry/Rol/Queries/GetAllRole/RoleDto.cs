using EventApi.Application.Features.UsersSrv.Queries.GetAllUser;

namespace EventApi.Application.Features.Securiry.Rol.Queries.GetAllRole
{
    public class RoleDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid UniqueId { get; set; }

    }
    public class RoleVM
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public List<RoleDto> Data { get; set; }
    }
}
