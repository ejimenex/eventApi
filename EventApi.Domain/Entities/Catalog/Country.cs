using EventApi.Domain.Common;

namespace EventApi.Domain.Entities.Catalog
{
    public class Country : BaseId
    {
        public string Name { get; set; }
        public bool IsAvaliable { get; set; }
        public virtual ICollection<Company> Company { get; set; }
        public virtual ICollection<City> City { get; set; }

    }
}
