using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models
{
	public class BasketItem
	{
		public Guid basketItemId { get; set; }
		public Guid basketId { get; set; }
		public int productId { get; set; }
		public int quantity { get; set; }
		public Product product { get; set; }
	}
}
