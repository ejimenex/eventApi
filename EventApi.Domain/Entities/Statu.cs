using EventApi.Domain.Common;
using System.Runtime.InteropServices;

namespace EventApi.Domain.Entities
{
    public class Statu:BaseId
    {
        public string Name { get; set;}
        public virtual ICollection<Activities> Activities { get; set; }
    }
}
