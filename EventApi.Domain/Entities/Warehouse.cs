using EventApi.Domain.Common;

namespace EventApi.Domain.Entities
{
    public class Warehouse : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string WarehouseAddress { get; set; }
        public int? ActivitieId { get; set; }
        public virtual Activities Activities { get; set; }
    }
}
