using EventApi.Domain.Common;

namespace EventApi.Domain.Entities
{
    public class City:BaseAuditableEntity
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public ICollection<Activities> Activities { get; set; }
    }
}
