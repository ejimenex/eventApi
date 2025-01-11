using EventApi.Domain.Common;

namespace EventApi.Domain.Entities.Security
{
    public class RolPermission:BaseAuditableEntity
    {
        public Role Role { get; set; }
        public int RolId { get; set; }
        public Permission Permission { get; set; }
        public int PermissionId { get; set; }
    }
}
