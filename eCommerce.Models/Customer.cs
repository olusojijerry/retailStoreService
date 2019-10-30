using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models
{
	public class Customer
	{
		public int customerId { get; set; }
		public string customerName { get; set; }
		public string address1 { get; set; }
		public string town { get; set; }
		public string postCode { get; set; }
	}
}
