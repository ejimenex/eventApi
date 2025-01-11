using EventApi.Domain.Common;

namespace EventApi.Domain.Entities.Security
{
    public class UserAdittionalPermission:BaseAuditableEntity
    {
       public Permission Permission { get; set; }
       public int PermissionId { get; set; }
        public User User { get; set; }
       public int UserId { get; set; }
    }
}
