using BeeTex.Data.Entity.Enums;
using System.Collections.Generic;

namespace BeeTex.Data.Entity
{
	public class OrderEntity: TrackableEntityBase
	{
		public OrderEntity()
		{
			this.Products = new List<ProductEntity>();
		}
		public UserEntity Client { get; set; }
		
		public StatusCode OrderStatus { get; set; }

		public IEnumerable<ProductEntity> Products { get; set; }
	}
}
