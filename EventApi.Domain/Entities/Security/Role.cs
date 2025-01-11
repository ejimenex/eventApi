using EventApi.Domain.Common;

namespace EventApi.Domain.Entities.Security
{
    public class Role:BaseAuditableEntity
    {    
        public string Name { get; set; } 
        public string Description { get; set; }
        public ICollection<UserRole> UserRole { get; set; }
        public ICollection<RolPermission> RolPermission { get; set; }
    }
}
