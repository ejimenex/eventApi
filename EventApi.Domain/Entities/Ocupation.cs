using EventApi.Domain.Common;
using EventApi.Domain.Entities.Security;

namespace EventApi.Domain.Entities
{
    public class Ocupation : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
