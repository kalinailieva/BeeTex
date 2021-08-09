using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeTex.Data.Entity
{
	public class TrackableEntityBase
	{
        [Key]
        public Guid Id = Guid.NewGuid();

        [ForeignKey(nameof(CreatedByUserId))]
        public virtual UserEntity CreatedBy { get; set; }
        public string CreatedByUserId { get; set; }

        public DateTime? CreatedAt { get; set; }

        [ForeignKey(nameof(ModifiedByUserId))]
        public virtual UserEntity ModifiedBy { get; set; }
        public string ModifiedByUserId { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public bool IsActive { get; set; }
    }
}
