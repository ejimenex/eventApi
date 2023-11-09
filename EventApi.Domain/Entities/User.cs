using EventApi.Domain.Common;

namespace EventApi.Domain.Entities
{
    public class User : BaseAuditableEntity
    {
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsDisabled { get; set; }
        public Guid TenantId { get; set; }
        public DateTime LastLogin { get; set; }

    }
}
