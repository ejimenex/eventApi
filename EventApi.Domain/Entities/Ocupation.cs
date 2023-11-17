using EventApi.Domain.Common;

namespace EventApi.Domain.Entities
{
    public class Ocupation : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
