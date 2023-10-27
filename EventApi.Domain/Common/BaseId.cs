using System.ComponentModel.DataAnnotations;

namespace EventApi.Domain.Common
{
    public class BaseId
    {
        [Key]
        public int Id { get; set; }
    }
}
