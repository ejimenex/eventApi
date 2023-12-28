using EventApi.Domain.Common;

namespace EventApi.Domain.Entities
{
    public class Statu : BaseId
    {
        public string Name { get; set; }
        public virtual ICollection<Activities> Activities { get; set; }
        public virtual ICollection<ActivitiesEvents> ActivitiesEvents { get; set; }
    }
}
