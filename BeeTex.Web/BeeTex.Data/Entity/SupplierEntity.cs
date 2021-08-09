using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeTex.Data.Entity
{
	public class SupplierEntity
	{
		public Guid Id { get; set; }
		public string Name { get; set; }

		public string VatNumber { get; set; }

		public int TelephoneNumber { get; set; }

		public string AddressLine { get; set; }

	}
}
