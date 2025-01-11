using EventApi.Domain.Common;

namespace EventApi.Domain.Entities.Security
{
    public class PermissionUser : BaseId
    {
        public int UserId { get; set; }
        public string PermissionScope { get; set; }
    }
}
