using BeeTex.Data.Entity.Enums;
using System;
using System.Collections.Generic;

namespace BeeTex.Data.Entity
{
	public class InvoiceEntity: TrackableEntityBase
	{
		public int InvoiceNumber{ get; set; }
		public DateTime Date{ get; set; }
		public int PaymentTerm { get; set; }
		public int MyProperty { get; set; }

		public CompanyEntity Company { get; set; }

		public OrderEntity Order { get; set; }

		public decimal TotalPrice { get; set; }

		public decimal VAT { get; set; }

		public bool Cancelled { get; set; } //different from IsActive

		public WayOfDelivery DeliveryWay { get; set; }
	}
}
