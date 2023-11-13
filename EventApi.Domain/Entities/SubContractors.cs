using EventApi.Domain.Common;

namespace EventApi.Domain.Entities
{
    public class SubContractors : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string DocumentNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }

    }
}
