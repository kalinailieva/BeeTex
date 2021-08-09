using System;
using System.Collections.Generic;

namespace BeeTex.Data.Entity
{
	public class DeliveryEntity
	{
		public Guid Id{ get; set; }
		public DeliveryEntity()
		{
			this.Products = new List<ProductEntity>();
		}
		public SupplierEntity Supplier{ get; set; }

		public SupplierInvoiceEntity Invoice { get; set; }

		public IEnumerable<ProductEntity> Products { get; set; }

	}
}
