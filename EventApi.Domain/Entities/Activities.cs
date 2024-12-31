using EventApi.Domain.Common;

namespace EventApi.Domain.Entities
{
    public class Activities : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EstimatedEndDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int StatusId { get; set; }
        public int? CityId { get; set; }
        public virtual Statu Statu { get; set; }
        public virtual City City { get; set; }
    }
}
