using EventApi.Domain.Common;
using EventApi.Domain.Entities.Catalog;

namespace EventApi.Domain.Entities
{
    public class Company : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string DocumentNumber { get; set; }
        public Guid UniqueId { get; set; }
        public bool IsDisabled { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}
