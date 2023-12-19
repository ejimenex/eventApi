using EventApi.Domain.Common;

namespace EventApi.Domain.Entities
{
    public class Equipment:BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }

    }
}
