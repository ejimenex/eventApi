using EventApi.Domain.Common;

namespace EventApi.Domain.Entities.Security
{
    public class User : BaseAuditableEntity
    {
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsDisabled { get; set; }
        public DateTime LastLogin { get; set; }
        public int? OcupationId { get; set; }
        public string LanguageCode { get; set; }
        public string ExternalCode { get; set; }
        public bool IsVerified { get; set; }
        public int LoginQuantity { get; set; }

        public virtual Ocupation Ocupation { get; set; }
        public virtual ICollection<UserRole> UserRole
        {
            get; set;

        }
        public virtual ICollection<UserAdittionalPermission> UserAdittionalPermission
        {
            get; set;

        }
    }
}
