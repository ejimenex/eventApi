using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApi.Domain.Common
{
    public class BaseId
    {
        [Key]
        public int Id { get; set; }
    }
}
