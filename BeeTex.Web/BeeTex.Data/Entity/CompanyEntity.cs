using System;

namespace BeeTex.Data.Entity
{
	public class CompanyEntity
	{
		public Guid Id { get; set; }
		public string CompanyName { get; set; }
		public string Bulstat { get; set; }

		public string VatNumber { get; set; }

		public string Address { get; set; }

		public string OwnerName { get; set; }

		public string Comment { get; set; }

	}
}