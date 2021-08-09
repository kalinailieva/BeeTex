namespace BeeTex.Data.Entity
{
	public class ProductEntity: TrackableEntityBase
{
		public string Name { get; set; }
		public string Description { get; set; }

		public decimal DeliveryPrice { get; set; }

		public int StockQuantity { get; set; }

		public decimal InitialSellPriceWithoutVat { get; set; }
		public decimal DiscountSellPriceWithoutVat { get; set; }

		public CollectionEntity Collection { get; set; }
	}
}