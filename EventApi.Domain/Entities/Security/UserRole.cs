using EventApi.Domain.Common;

namespace EventApi.Domain.Entities.Security
{
    public class UserRole : BaseAuditableEntity
    {
        public virtual Role Role{ get; set; }
        public int RolId { get; set; }
        public virtual User User{get;set;}
        public int UserId { get; set; }
    }
}
