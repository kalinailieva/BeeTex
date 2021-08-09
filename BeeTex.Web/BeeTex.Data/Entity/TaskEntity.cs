using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeTex.Data.Entity
{
	public class TaskEntity : TrackableEntityBase
	{
		public string Description { get; set; }

		public bool Important { get; set; }

		[ForeignKey(nameof(UserEntityId))]
		public UserEntity User { get; set; }
		public string UserEntityId { get; set; }


	}
}
