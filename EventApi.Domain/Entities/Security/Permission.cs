using EventApi.Domain.Common;

namespace EventApi.Domain.Entities.Security
{
    public class Permission : BaseId
    {
        public string Name { get; set; }
        public string Scope { get; set; }
        public ICollection<RolPermission> RolPermission { get; set; }
        public ICollection<UserAdittionalPermission> UserAdittionalPermission { get; set; }
    }
}
