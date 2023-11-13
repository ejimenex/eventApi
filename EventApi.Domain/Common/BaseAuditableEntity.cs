namespace EventApi.Domain.Common
{
    public class BaseAuditableEntity : BaseId

    {
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public Guid TenantId { get; set; }

    }
}
