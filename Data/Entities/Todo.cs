using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    public class Todo : BaseEntity
    {
        public DateTime? ExpiredAt { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        public decimal? PercentComplete { get; set; }

        [DefaultValue(false)]
        public bool IsDone { get; set; } = false;
    }
}
