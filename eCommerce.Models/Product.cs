using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models
{
	public class Product
	{
		public int productId { get; set; }
		public string description { get; set; }
		[MaxLength(255)]
		public string imageUrl { get; set; }
		public decimal price { get; set; }
		public decimal costPrice { get; set; }
	}
}
