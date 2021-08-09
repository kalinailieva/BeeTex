using System;

namespace BeeTex.Data.Entity
{
	public class SupplierInvoiceEntity
	{
		public Guid Id { get; set; }
		public int InvoiceNumber { get; set; }
		public DateTime IssueDate { get; set; }

		public DateTime PaymentDate { get; set; }

		public decimal TotalAmount { get; set; }

		public SupplierEntity Supplier { get; set; }

		public bool IsPaid { get; set; }
	}
}
