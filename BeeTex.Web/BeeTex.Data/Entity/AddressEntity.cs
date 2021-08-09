using System;
using System.ComponentModel.DataAnnotations;

namespace BeeTex.Data.Entity
{
	public class AddressEntity
	{
		public Guid Id{ get; set; }
		public string Country { get; set; }
		public string AddressLine { get; set; }
	}
}