﻿using EventApi.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

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
        [ForeignKey(nameof(StatusId))]
        public virtual Statu Statu { get; set; }
    }
}
