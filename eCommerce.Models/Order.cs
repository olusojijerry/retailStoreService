using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models
{
	public class Order
	{
		public int orderId { get; set; }
		public DateTime orderDate { get; set; }
		public int customerId { get; set; }
		public ICollection<OrderItem> orderItems { get; set; }
	}
}
