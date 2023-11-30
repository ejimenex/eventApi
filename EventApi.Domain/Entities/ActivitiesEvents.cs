using EventApi.Domain.Common;

namespace EventApi.Domain.Entities
{
    public class ActivitiesEvents:BaseAuditableEntity
    {
        public int StatusId {  get; set; }
        public int ActivitieId { get; set; }
        public virtual Statu Statu { get; set; }
    }
}
