using EventApi.Domain.Common;

namespace EventApi.Domain.Entities
{
    public class PermissionUser : BaseId
    {
        public int UserId { get; set; }
        public string PermissionScope { get; set; }
    }
}
