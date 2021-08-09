using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeTex.Data.Entity
{
	public class FashionFeed
	{
		public Guid Id { get; set; }

		public DateTime Date { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public  byte[] Image { get; set; }

		public bool TopNews { get; set; }
	}
}
