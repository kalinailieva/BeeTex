using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeTex.Data.Entity
{
	public class UserEntity : IdentityUser
	{
		public UserEntity()
		{
			this.Tasks = new List<TaskEntity>();
		}
		public string FirstName { get; set; }
		public string LastName { get; set; }

		[ForeignKey(nameof(AddressId))]
		public AddressEntity Address { get; set; }
		public Guid? AddressId { get; set; }

		[ForeignKey(nameof(CompanyId))]
		public CompanyEntity Company { get; set; }
		public Guid? CompanyId { get; set; }

		public string Details { get; set; }

		public bool IsActive { get; set; }

		public IEnumerable<TaskEntity> Tasks { get; set; }
	}
}
