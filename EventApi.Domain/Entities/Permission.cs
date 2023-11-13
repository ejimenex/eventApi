using EventApi.Domain.Common;

namespace EventApi.Domain.Entities
{
    public class Permission : BaseId
    {
        public string Name { get; set; }
        public string Scope { get; set; }
    }
}
