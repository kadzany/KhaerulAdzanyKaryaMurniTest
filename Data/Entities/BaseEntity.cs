using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    /// <summary>
    /// Base entity contains all the fields required for all entities in the system
    /// </summary>
    public class BaseEntity
    {
        public virtual int Id { get; set; }

        [MaxLength(20)]
        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        [MaxLength(20)]
        public string UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
