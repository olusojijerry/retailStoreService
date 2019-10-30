using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models
{
	public class OrderItem
	{
		public int orderItemId { get; set; }
		public int productId { get; set; }
		public int quantity { get; set; }
		public decimal price { get; set; }
	}
}
